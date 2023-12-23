using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MyInsurance.Infrastructure.Entities
{
    public class InsuranceRequestEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long UserId { get; set; }

        public string Title { get; set; }

        [ForeignKey(nameof(UserId))]
        public UsersEntity UsersEntity { get; set; }

        public required List<InsuranceRequestDetailEntity> RequestDetails { get; set; }
    }
}
