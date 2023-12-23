using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MyInsurance.Infrastructure.Entities
{
    [PrimaryKey(nameof(RequestId), nameof(CoverageId))]

    public class InsuranceRequestDetailEntity
    {
        public class Additional
        {
            public decimal? CoveragePercentage { get; set; }
            public string? CoverageTitle { get; set; }
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long RequestId { get; set; }

        public int CoverageId { get; set; }

        public int CoverageValue { get; set; }

        [ForeignKey(nameof(RequestId))]
        public InsuranceRequestEntity InsuranceRequestEntities { get; set; }

        [ForeignKey(nameof(CoverageId))]
        public CoverageEntity CoverageEntity { get; set; }

        [NotMapped]
        public Additional? AdditionalData { get; set; }
    }
}
