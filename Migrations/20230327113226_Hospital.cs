using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientCard.Migrations
{
    /// <inheritdoc />
    public partial class Hospital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdOrganozation",
                table: "Hospital");

            migrationBuilder.AlterColumn<string>(
                name: "Patronymic",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdOrganozation",
                table: "Hospital",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Patronymic",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);
        }
    }
}
