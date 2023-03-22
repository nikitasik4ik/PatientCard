using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientCard.Migrations
{
    /// <inheritdoc />
    public partial class UserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Analyze");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Analyze",
                type: "int",
                nullable: true);
        }
    }
}
