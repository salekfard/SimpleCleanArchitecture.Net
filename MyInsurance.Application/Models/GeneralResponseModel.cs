using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyInsurance.Application.Models
{
    public class GeneralResponseModel<T>(T result, bool isSuccess, string message = "")
    {
        public GeneralStatusModel? Status { get => new GeneralStatusModel(isSuccess, message); }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public T Result { get => result; }
    }

    public class GeneralResponseModel(bool isSuccess, string message = "")
    {
        public GeneralStatusModel? Status { get => new GeneralStatusModel(isSuccess, message); }
    }

    public class GeneralStatusModel(bool isSuccess, string message = "")
    {
        public bool IsSuccess { get; set; } = isSuccess;
        public string Message { get; set; } = message;
        public DateTime SystemDateTime { get => DateTime.Now; }
        public string systemTimeStamp
        {
            get
            {
                return new DateTimeOffset(this.SystemDateTime).ToUnixTimeMilliseconds().ToString();
            }
        }
    }
}
