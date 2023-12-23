using System.Text.Json.Serialization;

namespace MyInsurance.Presentation.Models
{
    public class StatusModel
    {
        public bool IsSuccess { get; set; }
        public required string Message { get; set; }
        public int HttpStatusCode { get; set; }
        public DateTime SystemDateTime
        {
            get
            {
                return DateTime.Now;
            }
        }
        public string SystemTimeStamp
        {
            get
            {
                return new DateTimeOffset(SystemDateTime).ToUnixTimeMilliseconds().ToString();
            }
        }
    }
}
