using System.ComponentModel.DataAnnotations;
using IraniValidator;
using MyInsurance.Application.Helpers.Exceptions;
using MyInsurance.Domain.Resources;

namespace MyInsurance.Application.Models.DTOs
{
    public class CreateUserDTO
    {
        private string _nationalCode;
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = nameof(Messages.NationalCodeRequired))]
        public string NationalCode
        {
            get => _nationalCode;
            set
            {
                if (value.IsValidPersonNationalId())
                {
                    _nationalCode = value;
                }
                else
                {
                    throw new GeneralException(Messages.NationalCodeInvalid);
                }
            }
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
