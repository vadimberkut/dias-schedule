using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScheduleApp.Helpers;
using ScheduleApp.Models;

namespace ScheduleApp.ViewModels
{
    public class ScheduleViewModel
    {
        //public List<String> WorkdaysOfWeek = new List<String>() { "Monday", "Thuesday", "Wednesday", "Thursday", "Friday"};
        public List<String> WorkdaysOfWeek = new List<String>();
//        public enum WorkdaysOfWeek
//        {
//            Monday = WorkdayOfWeek.Monday,
//            Thuesday = WorkdayOfWeek.Thuesday,
//            Wednesday = WorkdayOfWeek.Wednesday,
//            Thursday = WorkdayOfWeek.Thursday,
//            Friday = WorkdayOfWeek.Friday,
//        };

        public ScheduleViewModel()
        {
            var values = EnumHelper.GetValues<WorkdayOfWeek>();
            foreach (var val in values)
            {
                WorkdaysOfWeek.Add(val.ToString());
            }
        }

        public int MAX_LESSONS_PER_DAY = 5;
        public int MAX_COURSES = 5;
        public int course;

        public Semester Semester;
        public IEnumerable<Group> Groups;
        public IEnumerable<ScheduleItem> ScheduleItems;

        public IEnumerable<Restriction> Restrictions;

        //public ApplicationUser User;

        public bool BelongsToAdminRole = false;

        public bool CheckScheduleItem(int semesterId, string dayOfWeek, int lessonNumber, int groupId)
        {
            var result = this.ScheduleItems.Where(i => i.SemesterId == semesterId && i.DayOfWeek == dayOfWeek && i.LessonNumber == lessonNumber && i.GroupId == groupId && (i.LessonFrequency == LessonFrequency.Constant || i.LessonFrequency == LessonFrequency.Nominator || i.LessonFrequency == LessonFrequency.Denominator)).ToArray();
            return result.Length == 1 || result.Length == 2 ? true : false; //
        } 
        public bool CheckScheduleItem(int semesterId, string dayOfWeek, int lessonNumber, int groupId, LessonFrequency lessonFrequency)
        {
            var result = this.ScheduleItems.Where(i => i.SemesterId == semesterId && i.DayOfWeek == dayOfWeek && i.LessonNumber == lessonNumber && i.GroupId == groupId && i.LessonFrequency == lessonFrequency).ToArray();
            return result.Length == 1 ? true : false;
        }
        public List<ScheduleItem> GetScheduleItems(int semesterId, string dayOfWeek, int lessonNumber, int groupId)
        {
            return this.ScheduleItems.Where(i => i.SemesterId == semesterId && i.DayOfWeek == dayOfWeek && i.LessonNumber == lessonNumber && i.GroupId == groupId).ToList();
        }

        public ScheduleItem GetScheduleItem(int semesterId, string dayOfWeek, int lessonNumber, int groupId, LessonFrequency lessonFrequency)
        {
            return this.ScheduleItems.Where(i => i.SemesterId == semesterId && i.DayOfWeek == dayOfWeek && i.LessonNumber == lessonNumber && i.GroupId == groupId && i.LessonFrequency == lessonFrequency).Single();
        }

        //проверяет можно ли добавить занятие на этот день (или на постоянно или на числитель или на знаменталь)
        public bool StudLessonsLimitReached(string day, int groupId)
        {

            return StudLessonsLimitReached(day, groupId, LessonFrequency.Nominator) || StudLessonsLimitReached(day, groupId, LessonFrequency.Denominator);
        }

        //проверет можно ли назначить занятие на числитель или знаменатель
        public bool StudLessonsLimitReached(string day, int groupId, LessonFrequency frequency)
        {
            if (frequency == LessonFrequency.Constant)
            {
                return StudLessonsLimitReached(day, groupId);
            }

            WorkdayOfWeek dayValue = (WorkdayOfWeek)Enum.Parse(typeof(WorkdayOfWeek), day);
            int lessonsForDay = ScheduleItems.Count(i => i.GroupId == groupId && i.DayOfWeek == day && (i.LessonFrequency == LessonFrequency.Constant || i.LessonFrequency == frequency));
            int MaxLessonsPerDayForStudents =
                System.Convert.ToInt32(
                    Restrictions.Single(i => i.Name == "MaxLessonsPerDayForStudents").Value);
            return lessonsForDay >= MaxLessonsPerDayForStudents;
        }

    }
}