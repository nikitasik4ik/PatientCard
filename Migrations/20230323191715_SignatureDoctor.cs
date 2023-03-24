using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientCard.Migrations
{
    /// <inheritdoc />
    public partial class SignatureDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdSignatureDoctor",
                table: "Recipe",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_IdSignatureDoctor",
                table: "Recipe",
                column: "IdSignatureDoctor");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_SignatureDoctor_IdSignatureDoctor",
                table: "Recipe",
                column: "IdSignatureDoctor",
                principalTable: "SignatureDoctor",
                principalColumn: "IdSignatureDoctor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_SignatureDoctor_IdSignatureDoctor",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_IdSignatureDoctor",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "IdSignatureDoctor",
                table: "Recipe");
        }
    }
}
