﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyInsurance.Infrastructure.Data;

#nullable disable

namespace MyInsurance.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231223014003_InitM")]
    partial class InitM
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyInsurance.Infrastructure.Entities.CoverageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("CalculationPercentage")
                        .HasPrecision(38, 20)
                        .HasColumnType("decimal(38,20)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MaxCapital")
                        .HasColumnType("int");

                    b.Property<int>("MinCapital")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Coverages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CalculationPercentage = 0.0052m,
                            IsActive = true,
                            MaxCapital = 500000000,
                            MinCapital = 5000,
                            Title = "پوشش جراحی"
                        },
                        new
                        {
                            Id = 2,
                            CalculationPercentage = 0.0042m,
                            IsActive = true,
                            MaxCapital = 400000000,
                            MinCapital = 4000,
                            Title = "پوشش دندانپزشکی"
                        },
                        new
                        {
                            Id = 3,
                            CalculationPercentage = 0.005m,
                            IsActive = true,
                            MaxCapital = 200000000,
                            MinCapital = 2000,
                            Title = "پوشش بستری"
                        });
                });

            modelBuilder.Entity("MyInsurance.Infrastructure.Entities.InsuranceRequestDetailEntity", b =>
                {
                    b.Property<long>("RequestId")
                        .HasColumnType("bigint");

                    b.Property<int>("CoverageId")
                        .HasColumnType("int");

                    b.Property<int>("CoverageValue")
                        .HasColumnType("int");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.HasKey("RequestId", "CoverageId");

                    b.HasIndex("CoverageId");

                    b.ToTable("InsuranceRequestDetails");
                });

            modelBuilder.Entity("MyInsurance.Infrastructure.Entities.InsuranceRequestEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("InsuranceRequests");
                });

            modelBuilder.Entity("MyInsurance.Infrastructure.Entities.UsersEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasColumnType("char(10)");

                    b.HasKey("Id");

                    b.HasIndex("NationalCode")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyInsurance.Infrastructure.Entities.InsuranceRequestDetailEntity", b =>
                {
                    b.HasOne("MyInsurance.Infrastructure.Entities.CoverageEntity", "CoverageEntity")
                        .WithMany("InsuranceRequestDetailEntities")
                        .HasForeignKey("CoverageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyInsurance.Infrastructure.Entities.InsuranceRequestEntity", "InsuranceRequestEntities")
                        .WithMany("RequestDetails")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CoverageEntity");

                    b.Navigation("InsuranceRequestEntities");
                });

            modelBuilder.Entity("MyInsurance.Infrastructure.Entities.InsuranceRequestEntity", b =>
                {
                    b.HasOne("MyInsurance.Infrastructure.Entities.UsersEntity", "UsersEntity")
                        .WithMany("InsuranceRequestEntity")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsersEntity");
                });

            modelBuilder.Entity("MyInsurance.Infrastructure.Entities.CoverageEntity", b =>
                {
                    b.Navigation("InsuranceRequestDetailEntities");
                });

            modelBuilder.Entity("MyInsurance.Infrastructure.Entities.InsuranceRequestEntity", b =>
                {
                    b.Navigation("RequestDetails");
                });

            modelBuilder.Entity("MyInsurance.Infrastructure.Entities.UsersEntity", b =>
                {
                    b.Navigation("InsuranceRequestEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
