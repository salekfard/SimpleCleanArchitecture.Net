using System.ComponentModel.DataAnnotations;
using MyInsurance.Domain.Resources;

namespace MyInsurance.Domain.Entities
{
    public class Users
    {
        public long Id { get; set; }
        public required string NationalCode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
