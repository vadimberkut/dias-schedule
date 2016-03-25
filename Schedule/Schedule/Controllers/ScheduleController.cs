using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Schedule.Context;
using Schedule.Helpers;
using Schedule.Models;

namespace Schedule.Controllers
{
    public class ScheduleController : Controller
    {
        //ApplicationDbContext context = new ApplicationDbContext();
        //
        // GET: /Schedule/

        public ActionResult Index()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                //var a = context.Groups.ToList();
                ViewBag.Groups = context.Groups.OrderBy(i => i.Title).ToList();
                //int semesterId = context.Semesters.Where(i => i.StartsOn.Year == DateTime.Now.Year).Single().Id;
                int semesterId = 1;
                var schedules = context.ScheduleItems.Where(i => i.SemesterId == semesterId)
                    .Include(i => i.Group)
                    .Include(i => i.Lesson)
                    .Include(i => i.Teacher)
                    .Include(i => i.Classroom)
                    .Include(i => i.Semester)
                    .ToList();

                Hashtable schedulesHashtable = new Hashtable();
                foreach (var item in schedules)
                {
                    string key = String.Format("{0}_{1}_{2}_{3}_{4}", item.SemesterId, item.DayOfWeek, item.LessonNumber,item.GroupId, item.LessonFrequency);
                    if(schedulesHashtable.ContainsKey(key) == false)
                        schedulesHashtable.Add(key, item);
                }

                ViewBag.SchedulesHashtable = schedulesHashtable;
                ViewBag.Semester = semesterId;

                return View();
            }
        }

        public PartialViewResult _LessonForm(int semesterId, string dayOfWeek, int lessonNumber, int groupId)
        {
            Models.ScheduleItem schedule = new ScheduleItem()
            {
                SemesterId = semesterId,
                DayOfWeek = dayOfWeek,
                LessonNumber = lessonNumber,
                GroupId = groupId
            };

            ViewBag.LessonId = GetLessons();
            ViewBag.LessonType = GetLessonTypes();
            ViewBag.TeacherId = GetTeachers();
            ViewBag.ClassroomId = GetClassrooms();

            return PartialView("_LessonFormPartial", schedule);
        }

        [HttpPost]
        public ActionResult AddLesson(ScheduleItem schedule)
        {
            try
            {
                // TODO: Add insert logic here
                ApplicationDbContext context = ApplicationDbContext.Create();
                if (ModelState.IsValid)
                {
                    context.ScheduleItems.Add(schedule);
                }
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
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

        private IEnumerable<SelectListItem> GetLessons(int? selectedValue = null)
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

        private IEnumerable<SelectListItem> GetLessonTypes(string selectedValue = null)
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

        private IEnumerable<SelectListItem> GetTeachers(int? selectedValue = null)
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

        private IEnumerable<SelectListItem> GetClassrooms(int? selectedValue = null)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var values = context.Classrooms.ToList();

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
