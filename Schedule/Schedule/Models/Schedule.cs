using System;

namespace Schedule.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; } 
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; } 
        public int ClassroomId { get; set; }
        public virtual Classroom Classroom { get; set; } 
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; } 

        //TODO: Возможно указывать только номер пары?
        public DateTime StartsOn { get; set; }  
        public DateTime EndsOn { get; set; }  
    }
}