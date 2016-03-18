namespace Schedule.Models
{
    public class GroupWorkload
    {
        public int Id { get; set; }  
        public int GroupId { get; set; }
        public virtual Group Group { get; set; } 
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; } 
        public string LessonType { get; set; }  
        public int Hours { get; set; }  
    }
}