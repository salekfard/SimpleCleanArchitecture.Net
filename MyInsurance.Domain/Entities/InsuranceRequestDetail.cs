using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyInsurance.Domain.Entities
{
    public class InsuranceRequestDetail
    {
        public class Additional
        {
            public decimal? CoveragePercentage { get; set; }
            public string? CoverageTitle { get; set; }
        }
        public long Id { get; set; }

        public long RequestId { get; set; }

        public int CoverageId { get; set; }

        public int CoverageValue { get; set; }

        public Additional? AdditionalData { get; set; }
    }
}
