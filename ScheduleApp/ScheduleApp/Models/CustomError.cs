namespace ScheduleApp.Models
{
    public class CustomError
    {
        public string Message { get; set; }

        public CustomError(string msg)
        {
            this.Message = msg;
        }
    }
}