using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleApp.Models;

namespace ScheduleApp.Helpers
{
    public class ScheduleItemIdModel
    {
        public int SemesterId { get; set; }
        public string DayOfWeek { get; set; }
        public int LessonNumber { get; set; }
        public int GroupId { get; set; }
        public LessonFrequency LessonFrequency { get; set; }
    }

    public class ClassroomInfoModel : Classroom
    {
        //public int ClassroomId { get; set; }
        public bool Available { get; set; }
    }

    public enum ScheduleAccessMode
    {
        View,
        Edit,
        Full
    }

    public class ScheduleHelper
    {
        public static int GetCurrentSemesterId()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            int semesterId = context.Semesters.Single(i => i.StartsOn <= DateTime.Now && DateTime.Now <= i.EndsOn).Id;
            return semesterId;
        }

        public static ScheduleItemIdModel ParseScheduleItemId(string id)
        {
//                if (info.length === 5) {
//                    obj.lessonFrequency = info[4];
//                };

            var parts = id.Split('_');

            ScheduleItemIdModel model = new ScheduleItemIdModel()
            {
                SemesterId = Convert.ToInt32(parts[0]),
                DayOfWeek = parts[1],
                LessonNumber = Convert.ToInt32(parts[2]),
                GroupId = Convert.ToInt32(parts[3]),
                LessonFrequency = EnumHelper.GetEnumFromString<LessonFrequency>(parts[4])
            };
            return model;
        }

        public static ClassroomInfoModel CreateClassroomInfoModel(Classroom classroom, bool available = false)
        {
            return new ClassroomInfoModel()
            {
                Id = classroom.Id,
                Capacity = classroom.Capacity,
                Number = classroom.Number,
                Type = classroom.Type,
                Available = available //DEFAULT FALSE
            };
        }

        public static List<ClassroomInfoModel> GetFreeClassrooms(ClassroomType type,ScheduleItemIdModel idModel)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            List<ClassroomInfoModel> classrooms = new List<ClassroomInfoModel>();

            var group = context.Groups.Single(i => i.Id == idModel.GroupId);
            var unavailableIds = context.ScheduleItems
                .Where(i => i.SemesterId == idModel.SemesterId && i.DayOfWeek == idModel.DayOfWeek && i.LessonNumber == idModel.LessonNumber && i.LessonFrequency == idModel.LessonFrequency)
                .Select(i => i.ClassroomId)
                .ToList();
            var unavailable = context.Classrooms.Where(i => unavailableIds.Contains(i.Id)).ToList();
            var available = context.Classrooms
                .Where(j => unavailableIds.Contains(j.Id) == false) //Filter unavailable
                .Where(i => i.Capacity >= group.StudentsAmount && i.Type == type) //Check Capacity and Type
                .ToList();

            foreach (var item in available)
            {
                classrooms.Add(ScheduleHelper.CreateClassroomInfoModel(item, true));
            }
            foreach (var item in unavailable)
            {
                classrooms.Add(ScheduleHelper.CreateClassroomInfoModel(item, false));
            }

            return classrooms;
        }
    }
}