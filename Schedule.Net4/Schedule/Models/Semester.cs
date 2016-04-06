using System;

namespace Schedule.Models
{
    public class Semester
    {
        public int Id { get; set; }
        public DateTime StartsOn { get; set; }
        public DateTime EndsOn { get; set; } 
    }
}