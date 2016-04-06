namespace ScheduleApp.Models
{
    public class Classroom
    {
        public int Id { get; set; } 
        public int Capacity { get; set; }
        public ClassroomType Type { get; set; } 
        public string Number { get; set; } 
    }
}