using System;

namespace Schedule.Models
{
    public enum LessonType : int
    {
        Lec = 1,
        Lab = 2,
        Prac = 3,
    }
    public enum LessonFrequency : int
    {
        Constant = 1,
        Nominator = 2,
        Denominator = 3,
    }


    public class ScheduleItem
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; } 
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }
        public LessonType LessonType { get; set; }
        public int ClassroomId { get; set; }
        public virtual Classroom Classroom { get; set; } 
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; } 

        //TODO: Возможно указывать только номер пары?
//        public DateTime StartsOn { get; set; }  
//        public DateTime EndsOn { get; set; }  

        public int SemesterId { get; set; }
        public virtual Semester Semester { get; set; } 
        public string DayOfWeek { get; set; }
        public int LessonNumber { get; set; }
        public LessonFrequency LessonFrequency { get; set; }
    }
}