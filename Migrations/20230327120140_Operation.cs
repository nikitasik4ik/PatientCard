using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientCard.Migrations
{
    /// <inheritdoc />
    public partial class Operation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameOperation",
                table: "Operation",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameOperation",
                table: "Operation");
        }
    }
}
