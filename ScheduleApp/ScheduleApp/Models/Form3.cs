namespace ScheduleApp.Models
{
    public class Form3
    {
        public int Id { get; set; } 
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }
        public LessonType LessonType { get; set; }
        public int Hours { get; set; }

        //Группа, Чассы на лекцию практику лабы, консультации,...
    }
}