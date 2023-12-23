using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyInsurance.Domain.Resources;

namespace MyInsurance.Domain.Entities
{
    public class InsuranceRequest
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public string Title { get; set; }

        public List<InsuranceRequestDetail> RequestDetails {  get; set; }
    }
}
