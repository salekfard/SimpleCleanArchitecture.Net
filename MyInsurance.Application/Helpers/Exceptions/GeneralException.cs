using MyInsurance.Domain.Resources;

namespace MyInsurance.Application.Helpers.Exceptions
{
    public class GeneralException : Exception
    {
        public GeneralException(string message, Exception? innerException = null)
        : base(message, innerException)
        {
            // Additional custom exception properties or initialization logic
        }
    }
}
