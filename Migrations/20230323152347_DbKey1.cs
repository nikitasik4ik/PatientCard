using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientCard.Migrations
{
    /// <inheritdoc />
    public partial class DbKey1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdOrganozation",
                table: "Stydy");

            migrationBuilder.DropColumn(
                name: "IdOrganozation",
                table: "Polyclinic");

            migrationBuilder.DropColumn(
                name: "IdOrganozation",
                table: "Operation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdOrganozation",
                table: "Stydy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdOrganozation",
                table: "Polyclinic",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdOrganozation",
                table: "Operation",
                type: "int",
                nullable: true);
        }
    }
}
