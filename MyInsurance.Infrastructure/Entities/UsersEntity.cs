using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyInsurance.Infrastructure.Entities
{
    public class UsersEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = "char(10)")]
        public required string NationalCode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public List<InsuranceRequestEntity> InsuranceRequestEntity { get; set; }

    }

    public class UsersEntityConfiguration : IEntityTypeConfiguration<UsersEntity>
    {
        public void Configure(EntityTypeBuilder<UsersEntity> builder)
        {
            builder.HasIndex(x => x.NationalCode).IsUnique();
        }
    }
}
