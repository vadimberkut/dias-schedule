using System;

namespace ScheduleApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }  
        public string FirstName { get; set; }  
        public string LastName { get; set; }  
        public string MiddleName { get; set; }  
        public string Gender { get; set; }  
        public DateTime DateOfBirth { get; set; }

        public string GetFullNameLong()
        {
            return String.Format("{0} {1} {2}",this.LastName,this.FirstName,this.MiddleName);
        }
        public string GetFullNameShort()
        {
            return String.Format("{0} {1}.{2}.", this.LastName, this.FirstName.Substring(0, 1), this.MiddleName.Substring(0, 1));
        }
    }
}