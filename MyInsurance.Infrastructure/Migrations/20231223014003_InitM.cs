using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyInsurance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coverages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinCapital = table.Column<int>(type: "int", nullable: false),
                    MaxCapital = table.Column<int>(type: "int", nullable: false),
                    CalculationPercentage = table.Column<decimal>(type: "decimal(38,20)", precision: 38, scale: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coverages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalCode = table.Column<string>(type: "char(10)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceRequests",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceRequestDetails",
                columns: table => new
                {
                    RequestId = table.Column<long>(type: "bigint", nullable: false),
                    CoverageId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoverageValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceRequestDetails", x => new { x.RequestId, x.CoverageId });
                    table.ForeignKey(
                        name: "FK_InsuranceRequestDetails_Coverages_CoverageId",
                        column: x => x.CoverageId,
                        principalTable: "Coverages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsuranceRequestDetails_InsuranceRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "InsuranceRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Coverages",
                columns: new[] { "Id", "CalculationPercentage", "IsActive", "MaxCapital", "MinCapital", "Title" },
                values: new object[,]
                {
                    { 1, 0.0052m, true, 500000000, 5000, "پوشش جراحی" },
                    { 2, 0.0042m, true, 400000000, 4000, "پوشش دندانپزشکی" },
                    { 3, 0.005m, true, 200000000, 2000, "پوشش بستری" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequestDetails_CoverageId",
                table: "InsuranceRequestDetails",
                column: "CoverageId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequests_UserId",
                table: "InsuranceRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NationalCode",
                table: "Users",
                column: "NationalCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceRequestDetails");

            migrationBuilder.DropTable(
                name: "Coverages");

            migrationBuilder.DropTable(
                name: "InsuranceRequests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
