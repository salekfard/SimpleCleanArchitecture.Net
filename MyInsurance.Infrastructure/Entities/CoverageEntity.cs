using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyInsurance.Domain.Resources;

namespace MyInsurance.Infrastructure.Entities
{
    public class CoverageEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public required string Title { get; set; }

        public int MinCapital { get; set; }

        public int MaxCapital { get; set; }

        [Precision(38, 20)]
        public decimal CalculationPercentage { get; set; }

        public bool IsActive { get; set; }

        public List<InsuranceRequestDetailEntity> InsuranceRequestDetailEntities { get; set; }
    }

    public class CoverageEntityConfiguration : IEntityTypeConfiguration<CoverageEntity>
    {
        public void Configure(EntityTypeBuilder<CoverageEntity> builder)
        {
            builder.HasData(
                new CoverageEntity() { Id = 1, Title = Messages.Covarage1, MinCapital = 5000, MaxCapital = 500000000, CalculationPercentage = 0.0052M, IsActive = true},
                new CoverageEntity() { Id = 2, Title = Messages.Covarage2, MinCapital = 4000, MaxCapital = 400000000, CalculationPercentage = 0.0042M, IsActive = true },
                new CoverageEntity() { Id = 3, Title = Messages.Covarage3, MinCapital = 2000, MaxCapital = 200000000, CalculationPercentage = 0.005M, IsActive = true });
        }
    }
}
