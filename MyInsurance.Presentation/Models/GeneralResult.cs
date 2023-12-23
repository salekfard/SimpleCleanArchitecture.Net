using System.Text.Json.Serialization;

namespace MyInsurance.Presentation.Models
{
    public class GeneralResult<T>
    {
        public required StatusModel Status { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public T? Result { get; set; }
    }
}
