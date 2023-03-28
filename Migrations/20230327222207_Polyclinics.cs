using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientCard.Migrations
{
    /// <inheritdoc />
    public partial class Polyclinics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polyclinic_Analyze_AnalyzeIdAnalyzes",
                table: "Polyclinic");

            migrationBuilder.RenameColumn(
                name: "AnalyzeIdAnalyzes",
                table: "Polyclinic",
                newName: "IdDoctor");

            migrationBuilder.RenameIndex(
                name: "IX_Polyclinic_AnalyzeIdAnalyzes",
                table: "Polyclinic",
                newName: "IX_Polyclinic_IdDoctor");

            migrationBuilder.AddForeignKey(
                name: "FK_Polyclinic_Doctor_IdDoctor",
                table: "Polyclinic",
                column: "IdDoctor",
                principalTable: "Doctor",
                principalColumn: "IdDoctor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polyclinic_Doctor_IdDoctor",
                table: "Polyclinic");

            migrationBuilder.RenameColumn(
                name: "IdDoctor",
                table: "Polyclinic",
                newName: "AnalyzeIdAnalyzes");

            migrationBuilder.RenameIndex(
                name: "IX_Polyclinic_IdDoctor",
                table: "Polyclinic",
                newName: "IX_Polyclinic_AnalyzeIdAnalyzes");

            migrationBuilder.AddForeignKey(
                name: "FK_Polyclinic_Analyze_AnalyzeIdAnalyzes",
                table: "Polyclinic",
                column: "AnalyzeIdAnalyzes",
                principalTable: "Analyze",
                principalColumn: "IdAnalyzes");
        }
    }
}
