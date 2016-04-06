using System;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using ScheduleApp.Models;
using ScheduleApp.ViewModels;

namespace ScheduleApp.Repositories
{
    public class ScheduleRepository
    {
        public static ScheduleViewModel GetScheduleViewModel(int semesterId, int course = 1)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            ScheduleViewModel vm = new ScheduleViewModel();

            vm.course = course;
            vm.Semester = context.Semesters.Single(i => i.Id == semesterId);
            vm.Groups = context.Groups.Where(i => i.Course == course).ToList();     
            vm.ScheduleItems = context.ScheduleItems.Where(i => i.SemesterId == semesterId && i.Group.Course == course)
                .Include(i => i.Group)
                .Include(i => i.Lesson)
                .Include(i => i.Teacher)
                .Include(i => i.Classroom)
                .Include(i => i.Semester)
                .ToList();

            vm.Restrictions = context.Restrictions.ToList();

            return vm;
        }

        public static string GetSheduleItemKey(int semesterId, string dayOfWeek, int lessonNumber, int groupId)
        {
            return String.Format("{0}_{1}_{2}_{3}", semesterId, dayOfWeek, lessonNumber, groupId);
        }
        public static string GetSheduleItemKey(int semesterId,string dayOfWeek,int lessonNumber,int groupId,LessonFrequency lessonFrequency)
        {
            return String.Format("{0}_{1}_{2}_{3}_{4}", semesterId, dayOfWeek, lessonNumber, groupId, lessonFrequency);
        }
//        public static object ParseSheduleItemKey(int semesterId, string dayOfWeek, int lessonNumber, int groupId, LessonFrequency lessonFrequency)
//        {
//            return String.Format("{0}_{1}_{2}_{3}_{4}", semesterId, dayOfWeek, lessonNumber, groupId, lessonFrequency);
//            return new
//            {
//                
//            }
//        }
    }
}