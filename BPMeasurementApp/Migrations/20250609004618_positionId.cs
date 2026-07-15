using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BPMeasurementApp.Migrations
{
    /// <inheritdoc />
    public partial class positionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PositionId",
                table: "Measurements",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "MeasurementId",
                keyValue: 1,
                column: "PositionId",
                value: "st");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "MeasurementId",
                keyValue: 2,
                column: "PositionId",
                value: "ld");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "MeasurementId",
                keyValue: 3,
                column: "PositionId",
                value: "st");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "MeasurementId",
                keyValue: 4,
                column: "PositionId",
                value: "si");

            migrationBuilder.UpdateData(
                table: "Measurements",
                keyColumn: "MeasurementId",
                keyValue: 5,
                column: "PositionId",
                value: "si");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_PositionId",
                table: "Measurements",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Position_PositionId",
                table: "Measurements",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Position_PositionId",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_PositionId",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Measurements");
        }
    }
}
