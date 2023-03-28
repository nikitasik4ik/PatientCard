using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientCard.Migrations
{
    /// <inheritdoc />
    public partial class Fin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polyclinic_Stydy_StydyIdStydy",
                table: "Polyclinic");

            migrationBuilder.DropIndex(
                name: "IX_Polyclinic_StydyIdStydy",
                table: "Polyclinic");

            migrationBuilder.DropColumn(
                name: "StydyIdStydy",
                table: "Polyclinic");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StydyIdStydy",
                table: "Polyclinic",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Polyclinic_StydyIdStydy",
                table: "Polyclinic",
                column: "StydyIdStydy");

            migrationBuilder.AddForeignKey(
                name: "FK_Polyclinic_Stydy_StydyIdStydy",
                table: "Polyclinic",
                column: "StydyIdStydy",
                principalTable: "Stydy",
                principalColumn: "IdStydy");
        }
    }
}
