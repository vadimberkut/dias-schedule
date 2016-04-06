namespace ScheduleApp.Models
{
    public enum RestrictionType
    {
        Boolean,
        Integer,
        String,
        List
    }
    public class Restriction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RestrictionType Type { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
 
    }
}