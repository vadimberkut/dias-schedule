using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ScheduleApp.Helpers;
using ScheduleApp.Models;
using ScheduleApp.Repositories;
using ScheduleApp.ViewModels;

namespace ScheduleApp.Controllers
{
    public class ScheduleController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("View", new {course = 1});
        }

        public ActionResult View(int course = 1)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                int semesterId = ScheduleHelper.GetCurrentSemesterId();

                ScheduleViewModel vm = ScheduleRepository.GetScheduleViewModel(semesterId, course);

               //If user is admin then load access mode
                string userName = HttpContext.User.Identity.GetUserName();
                ViewBag.AccessMode = ScheduleAccessMode.View.ToString();
                if (HttpContext.User.IsInRole("Admin"))
                {                 
                    var roleStore = new RoleStore<IdentityRole>(context);
                    var roleManager = new RoleManager<IdentityRole>(roleStore);
                    var userStore = new UserStore<ApplicationUser>(context);
                    var userManager = new UserManager<ApplicationUser>(userStore);

                    var adminUser = userManager.FindByName(userName);
                   // var adminUser2 = context.Users.Single(i => i.UserName.ToString() == userName);
                    ViewBag.AccessMode = adminUser.ScheduleAccessMode.ToString();
                }

                return View("Index", vm);
            }
        }

        public ActionResult ChangeAcessMode(ScheduleAccessMode mode)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            if (HttpContext.User.IsInRole("Admin"))
            {                 
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                string userName = HttpContext.User.Identity.GetUserName();
                var adminUser = userManager.FindByName(userName);
                adminUser.ScheduleAccessMode = mode;
                try
                {
                    userManager.Update(adminUser);
                }
                catch (Exception ex)
                {
                    return RedirectToAction("View","Error",new CustomError(ex.Message));
                }
                string previousUrl = System.Web.HttpContext.Current.Request.UrlReferrer.AbsoluteUri;
                //return RedirectToAction("View", "Schedule", new { course = 1 });
                return Redirect(previousUrl);
            }
            return RedirectToAction("View", "Error", new CustomError("Access Denied"));
        }

        public PartialViewResult _LessonForm(int semesterId, string dayOfWeek, int lessonNumber, int groupId, LessonFrequency lessonFrequency = LessonFrequency.Constant)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            Models.ScheduleItem scheduleItem = new ScheduleItem()
            {
                SemesterId = semesterId,
                DayOfWeek = dayOfWeek,
                LessonNumber = lessonNumber,
                GroupId = groupId,
                LessonFrequency = lessonFrequency
            };
            scheduleItem.Group = context.Groups.Single(i => i.Id == groupId);

            //Отбираем значения числ/знам по загруж
            ScheduleViewModel vm = ScheduleRepository.GetScheduleViewModel(semesterId, scheduleItem.Group.Course);
            
            IEnumerable<SelectListItem> freqList =  GetLessonFrequenciesSelectList();

            Hashtable freqLimitReached = new Hashtable();

            foreach (var value in EnumHelper.GetValues<LessonFrequency>())
            {
                freqLimitReached.Add(value.ToString(), vm.StudLessonsLimitReached(dayOfWeek, groupId, value));
            }
            freqList = freqList.Where(i => (bool)freqLimitReached[i.Value] == false );    

            //проверка на другие занятия
            List<SelectListItem> freqList2 = new List<SelectListItem>();
            var scheduleItemsForConcreteLessonNumber = vm.GetScheduleItems(semesterId, dayOfWeek, lessonNumber, groupId).Select(i => i.LessonFrequency);
            if (scheduleItemsForConcreteLessonNumber.Contains(LessonFrequency.Constant))
            {
                freqList2.Clear();
            }
            else if (scheduleItemsForConcreteLessonNumber.Contains(LessonFrequency.Nominator))
            {
                freqList2.Add(freqList.SingleOrDefault(i => i.Value == LessonFrequency.Denominator.ToString()));
            }
            else if (scheduleItemsForConcreteLessonNumber.Contains(LessonFrequency.Denominator))
            {
                freqList2.Add(freqList.SingleOrDefault(i => i.Value == LessonFrequency.Nominator.ToString()));
            }
            else
            {
                freqList2.AddRange(freqList);
            }
            freqList = freqList2;

            ViewBag.LessonId = GetLessonsSelectList();
            ViewBag.LessonType = GetLessonTypesSelectList();
            ViewBag.LessonFrequency = freqList;
            ViewBag.TeacherId = GetTeachersSelectList();
            ViewBag.ClassroomId = GetClassroomsSelectList(context.Classrooms.Where(i => i.Capacity >= scheduleItem.Group.StudentsAmount).ToList());

            return PartialView("_LessonFormPartial", scheduleItem);
        }

        [HttpPost]
        public ActionResult AddLesson(ScheduleItem schedule)
        {
            try
            {
                // TODO: Add insert logic here
                ApplicationDbContext context = new ApplicationDbContext();
                if (ModelState.IsValid)
                {
                    context.ScheduleItems.Add(schedule);
                }
                context.SaveChanges();

                int course = context.Groups.Single(i => i.Id == schedule.GroupId).Course;

                return RedirectToAction("View", new { course = course });
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public JsonResult LessonsForGroup(int id)
        {
            int groupId = id;
            ApplicationDbContext context = new ApplicationDbContext();

            //TODO uncomment and add data to workload
            //var lessons = context.GroupsWorkload.Where(i => i.GroupId == groupId).Select(j => j.Lesson).ToList();

            var lessons = context.Lessons.ToList();

            return Json(lessons, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TeachersForLesson(int id, LessonType type, string elId)
        {
            ScheduleItemIdModel idModel = ScheduleHelper.ParseScheduleItemId(elId);

            int lessonId = id;
            LessonType lessonType = type;
            ApplicationDbContext context = new ApplicationDbContext();

            //Find teachers for this lesson number (to check further if teacher is unavailable)
            var teacherLessonsAcordingToElId = context.ScheduleItems
                .Where(
                    i =>
                        i.SemesterId == idModel.SemesterId && i.DayOfWeek == idModel.DayOfWeek &&
                        i.LessonNumber == idModel.LessonNumber && i.LessonFrequency == idModel.LessonFrequency)
                .ToList();
            var teacherLessonsIdsAcordingToElId = teacherLessonsAcordingToElId.Select(j => j.TeacherId).ToList();
            
            var teachers = context.Form3s
                .Where(i => i.LessonId == lessonId && i.LessonType == lessonType)
                .Where(k => (context.ScheduleItems.Count(i => i.LessonId == lessonId && i.TeacherId == k.TeacherId)) <= k.Hours) //Check GENERAL Hours
                .Where(z => teacherLessonsIdsAcordingToElId.Contains(z.TeacherId) == false) //Check acording to elId
                .Select(j => j.Teacher).ToList();

            //Check Max Lessons For This Day

            //get restriction
            Restriction MaxLessonsPerDayForTeachers = context.Restrictions.Single(i => i.Name == "MaxLessonsPerDayForTeachers");
            int maxLessons = Convert.ToInt32(MaxLessonsPerDayForTeachers.Value);

            List<ScheduleItem> scheduleItemsForDay = context.ScheduleItems.Where(
                    i =>
                        i.SemesterId == idModel.SemesterId && i.DayOfWeek == idModel.DayOfWeek 
                        //&& i.GroupId == idModel.GroupId
                        ).ToList();

            List<ScheduleItem> scheduleItemsForLesson = scheduleItemsForDay.Where(
                    i =>
                        i.LessonNumber == idModel.LessonNumber
                        ).ToList();

            List<Teacher> teachersFiltered = new List<Teacher>();
            foreach (var teacher in teachers)
            {
                
                int numOfLessonsNominator =
                 scheduleItemsForDay.Where(
                     i =>
                         i.TeacherId == teacher.Id &&
                         (i.LessonFrequency == LessonFrequency.Constant || i.LessonFrequency == LessonFrequency.Nominator))
                     .Count();
                int numOfLessonsDeminator =
                    scheduleItemsForDay.Where(
                        i =>
                            i.TeacherId == teacher.Id &&
                            (i.LessonFrequency == LessonFrequency.Constant || i.LessonFrequency == LessonFrequency.Denominator))
                        .Count();

                if (idModel.LessonFrequency == LessonFrequency.Constant)
                {
                    if (numOfLessonsNominator < maxLessons && numOfLessonsDeminator < maxLessons)
                    {
                        teachersFiltered.Add(teacher);
                    }
                }
                else if (idModel.LessonFrequency == LessonFrequency.Nominator)
                {
                    if (numOfLessonsNominator < maxLessons)
                    {
                        teachersFiltered.Add(teacher);
                    }
                }
                else if (idModel.LessonFrequency == LessonFrequency.Denominator)
                {
                    if (numOfLessonsDeminator < maxLessons)
                    {
                        teachersFiltered.Add(teacher);
                    }
                }
            }
            teachers = teachersFiltered;

            return Json(teachers, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ClassroomsForLesson(ClassroomType type, string elId)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            ScheduleItemIdModel idModel = ScheduleHelper.ParseScheduleItemId(elId);

//            var group = context.Groups.Single(i => i.Id == groupId);
//            var classrooms = context.Classrooms.Where(i => i.Capacity >= group.StudentsAmount && i.Type == type).ToList();

            //
            List<ClassroomInfoModel> classrooms = ScheduleHelper.GetFreeClassrooms(type, idModel);

            return Json(classrooms, JsonRequestBehavior.AllowGet);
        }

        public JsonResult StudLessonsLimitReached(string dayOfWeek, int groupId)//, LessonFrequency lessonFrequency)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            int semesterId = context.Semesters.Single(i => i.StartsOn <= DateTime.Now && DateTime.Now <= i.EndsOn).Id;
            var group = context.Groups.Single(i => i.Id == groupId);
            ScheduleViewModel vm = ScheduleRepository.GetScheduleViewModel(semesterId, group.Course);

            //bool reachedLimit = vm.StudLessonsLimitReached(dayOfWeek, groupId, lessonFrequency);

            Hashtable res = new Hashtable();

            foreach (var value in EnumHelper.GetValues<LessonFrequency>())
            {
                res.Add(value.ToString(), vm.StudLessonsLimitReached(dayOfWeek, groupId, value));
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Schedule/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Schedule/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Schedule/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Schedule/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Schedule/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Schedule/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Schedule/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private IEnumerable<SelectListItem> GetLessonsSelectList(int? selectedValue = null)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var values = context.Lessons.ToList();

            IEnumerable<SelectListItem> list =
                from value in values
                select new SelectListItem
                {
                    //Text = value.ToString(),
                    Text = value.Title,
                    Value = value.Id.ToString(),
                    Selected = value.Id == selectedValue,
                };

            return list;
        }

        private IEnumerable<SelectListItem> GetLessonTypesSelectList(string selectedValue = null)
        {
            IEnumerable<SelectListItem> list =
                from value in Statics.LessonTypes
                select new SelectListItem
                {
                    //Text = value.ToString(),
                    Text = value,
                    Value = value,
                    Selected = value == selectedValue,
                };

            return list;
        }
        private IEnumerable<SelectListItem> GetLessonFrequenciesSelectList(LessonFrequency selectedValue = LessonFrequency.Constant)
        {
            IEnumerable<SelectListItem> list =
                from value in EnumHelper.GetValues<LessonFrequency>()
                select new SelectListItem
                {
                    //Text = value.ToString(),
                    Text = value.ToString(),
                    Value = value.ToString(),
                    Selected = value.ToString() == selectedValue.ToString()
                };

            return list;
        }

        private IEnumerable<SelectListItem> GetTeachersSelectList(int? selectedValue = null)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var values = context.Teachers.ToList();

            IEnumerable<SelectListItem> list =
                from value in values
                select new SelectListItem
                {
                    //Text = value.ToString(),
                    Text = String.Format("{0} {1} {2}", value.LastName, value.FirstName, value.MiddleName),
                    Value = value.Id.ToString(),
                    Selected = value.Id == selectedValue,
                };

            return list;
        }

        private IEnumerable<SelectListItem> GetClassroomsSelectList(List<Classroom> values,int? selectedValue = null)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            if (values.Count == 0)
                values = context.Classrooms.ToList();

            IEnumerable<SelectListItem> list =
                from value in values
                select new SelectListItem
                {
                    //Text = value.ToString(),
                    Text = String.Format("{0} ({1} {2})", value.Number, value.Capacity, value.Type),
                    Value = value.Id.ToString(),
                    Selected = value.Id == selectedValue,
                };

            return list;
        }
	}
}