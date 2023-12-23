using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyInsurance.Infrastructure.Entities;

namespace MyInsurance.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) { }

        public DbSet<CoverageEntity> Coverages { get; set; }
        public DbSet<UsersEntity> Users { get; set; }
        public DbSet<InsuranceRequestEntity> InsuranceRequests { get; set; }

        public DbSet<InsuranceRequestDetailEntity> InsuranceRequestDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CoverageEntityConfiguration());
        }
    }
}
