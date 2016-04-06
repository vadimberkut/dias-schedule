using System;
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

//    public enum ScheduleAccessMode
//    {
//        View,
//        Full
//    }

    public class ScheduleHelper
    {
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
    }
}