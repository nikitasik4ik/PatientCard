using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientCard.Migrations
{
    /// <inheritdoc />
    public partial class Signature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SignatureDoctor",
                table: "Doctor");

            migrationBuilder.AddColumn<int>(
                name: "IdSignatureDoctor",
                table: "Doctor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SignatureDoctor",
                columns: table => new
                {
                    IdSignatureDoctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Certificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDoctor = table.Column<int>(type: "int", nullable: true),
                    ValidWith = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignatureDoctor", x => x.IdSignatureDoctor);
                    table.ForeignKey(
                        name: "FK_SignatureDoctor_Doctor_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IdDoctor");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_IdSignatureDoctor",
                table: "Doctor",
                column: "IdSignatureDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_SignatureDoctor_IdDoctor",
                table: "SignatureDoctor",
                column: "IdDoctor",
                unique: true,
                filter: "[IdDoctor] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_SignatureDoctor_IdSignatureDoctor",
                table: "Doctor",
                column: "IdSignatureDoctor",
                principalTable: "SignatureDoctor",
                principalColumn: "IdSignatureDoctor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_SignatureDoctor_IdSignatureDoctor",
                table: "Doctor");

            migrationBuilder.DropTable(
                name: "SignatureDoctor");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_IdSignatureDoctor",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "IdSignatureDoctor",
                table: "Doctor");

            migrationBuilder.AddColumn<string>(
                name: "SignatureDoctor",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
