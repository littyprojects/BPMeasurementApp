using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BPMeasurementApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    MeasurementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Systolic = table.Column<int>(type: "int", nullable: false),
                    Diastolic = table.Column<int>(type: "int", nullable: false),
                    DateTaken = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.MeasurementId);
                });

            migrationBuilder.InsertData(
                table: "Measurements",
                columns: new[] { "MeasurementId", "DateTaken", "Diastolic", "Systolic" },
                values: new object[,]
                {
                    { 1, new DateOnly(2008, 2, 7), 121, 181 },
                    { 2, new DateOnly(2005, 12, 29), 91, 142 },
                    { 3, new DateOnly(2002, 11, 24), 85, 131 },
                    { 4, new DateOnly(1998, 5, 8), 79, 122 },
                    { 5, new DateOnly(1996, 2, 9), 78, 118 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measurements");
        }
    }
}
