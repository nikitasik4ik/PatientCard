using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientCard.Migrations
{
    /// <inheritdoc />
    public partial class Organization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organization_Doctor_IdDoctor",
                table: "Organization");

            migrationBuilder.DropIndex(
                name: "IX_Organization_IdDoctor",
                table: "Organization");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Organization_IdDoctor",
                table: "Organization",
                column: "IdDoctor");

            migrationBuilder.AddForeignKey(
                name: "FK_Organization_Doctor_IdDoctor",
                table: "Organization",
                column: "IdDoctor",
                principalTable: "Doctor",
                principalColumn: "IdDoctor");
        }
    }
}
