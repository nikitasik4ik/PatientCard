using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientCard.Migrations
{
    /// <inheritdoc />
    public partial class Polyclinic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polyclinic_Analyze_IdAnalyze",
                table: "Polyclinic");

            migrationBuilder.DropForeignKey(
                name: "FK_Polyclinic_InspectionPoliclinics_InspectionPolyclinicId",
                table: "Polyclinic");

            migrationBuilder.DropForeignKey(
                name: "FK_Polyclinic_Stydy_IdStydy",
                table: "Polyclinic");

            migrationBuilder.DropTable(
                name: "Hospital");

            migrationBuilder.DropTable(
                name: "InspectionPoliclinics");

            migrationBuilder.DropTable(
                name: "InspectionHospital");

            migrationBuilder.DropTable(
                name: "Reception");

            migrationBuilder.DropIndex(
                name: "IX_Polyclinic_IdAnalyze",
                table: "Polyclinic");

            migrationBuilder.DropColumn(
                name: "IdAnalyze",
                table: "Polyclinic");

            migrationBuilder.RenameColumn(
                name: "InspectionPolyclinicId",
                table: "Polyclinic",
                newName: "StydyIdStydy");

            migrationBuilder.RenameColumn(
                name: "IdStydy",
                table: "Polyclinic",
                newName: "AnalyzeIdAnalyzes");

            migrationBuilder.RenameIndex(
                name: "IX_Polyclinic_InspectionPolyclinicId",
                table: "Polyclinic",
                newName: "IX_Polyclinic_StydyIdStydy");

            migrationBuilder.RenameIndex(
                name: "IX_Polyclinic_IdStydy",
                table: "Polyclinic",
                newName: "IX_Polyclinic_AnalyzeIdAnalyzes");

            migrationBuilder.AddColumn<string>(
                name: "AnamnesisDisease",
                table: "Polyclinic",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                table: "Polyclinic",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Recommendation",
                table: "Polyclinic",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Operation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Polyclinic_Analyze_AnalyzeIdAnalyzes",
                table: "Polyclinic",
                column: "AnalyzeIdAnalyzes",
                principalTable: "Analyze",
                principalColumn: "IdAnalyzes");

            migrationBuilder.AddForeignKey(
                name: "FK_Polyclinic_Stydy_StydyIdStydy",
                table: "Polyclinic",
                column: "StydyIdStydy",
                principalTable: "Stydy",
                principalColumn: "IdStydy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polyclinic_Analyze_AnalyzeIdAnalyzes",
                table: "Polyclinic");

            migrationBuilder.DropForeignKey(
                name: "FK_Polyclinic_Stydy_StydyIdStydy",
                table: "Polyclinic");

            migrationBuilder.DropColumn(
                name: "AnamnesisDisease",
                table: "Polyclinic");

            migrationBuilder.DropColumn(
                name: "Diagnosis",
                table: "Polyclinic");

            migrationBuilder.DropColumn(
                name: "Recommendation",
                table: "Polyclinic");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Operation");

            migrationBuilder.RenameColumn(
                name: "StydyIdStydy",
                table: "Polyclinic",
                newName: "InspectionPolyclinicId");

            migrationBuilder.RenameColumn(
                name: "AnalyzeIdAnalyzes",
                table: "Polyclinic",
                newName: "IdStydy");

            migrationBuilder.RenameIndex(
                name: "IX_Polyclinic_StydyIdStydy",
                table: "Polyclinic",
                newName: "IX_Polyclinic_InspectionPolyclinicId");

            migrationBuilder.RenameIndex(
                name: "IX_Polyclinic_AnalyzeIdAnalyzes",
                table: "Polyclinic",
                newName: "IX_Polyclinic_IdStydy");

            migrationBuilder.AddColumn<int>(
                name: "IdAnalyze",
                table: "Polyclinic",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InspectionHospital",
                columns: table => new
                {
                    IdInspectionHospital = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDepartament = table.Column<int>(type: "int", nullable: true),
                    IdDoctor = table.Column<int>(type: "int", nullable: true),
                    IdService = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Complaint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inspection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspectionPlan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionHospital", x => x.IdInspectionHospital);
                    table.ForeignKey(
                        name: "FK_InspectionHospital_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspectionHospital_Departament_IdDepartament",
                        column: x => x.IdDepartament,
                        principalTable: "Departament",
                        principalColumn: "IdDepartament");
                    table.ForeignKey(
                        name: "FK_InspectionHospital_Doctor_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IdDoctor");
                    table.ForeignKey(
                        name: "FK_InspectionHospital_Service_IdService",
                        column: x => x.IdService,
                        principalTable: "Service",
                        principalColumn: "IdService");
                });

            migrationBuilder.CreateTable(
                name: "InspectionPoliclinics",
                columns: table => new
                {
                    IdInspectionPoliclinic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDepartament = table.Column<int>(type: "int", nullable: true),
                    IdDoctor = table.Column<int>(type: "int", nullable: true),
                    IdService = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AnamnesisDisease = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complaints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recommendation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionPoliclinics", x => x.IdInspectionPoliclinic);
                    table.ForeignKey(
                        name: "FK_InspectionPoliclinics_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InspectionPoliclinics_Departament_IdDepartament",
                        column: x => x.IdDepartament,
                        principalTable: "Departament",
                        principalColumn: "IdDepartament");
                    table.ForeignKey(
                        name: "FK_InspectionPoliclinics_Doctor_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IdDoctor");
                    table.ForeignKey(
                        name: "FK_InspectionPoliclinics_Service_IdService",
                        column: x => x.IdService,
                        principalTable: "Service",
                        principalColumn: "IdService");
                });

            migrationBuilder.CreateTable(
                name: "Reception",
                columns: table => new
                {
                    IdReception = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAnalyze = table.Column<int>(type: "int", nullable: true),
                    IdDepartament = table.Column<int>(type: "int", nullable: true),
                    IdDoctor = table.Column<int>(type: "int", nullable: true),
                    IdService = table.Column<int>(type: "int", nullable: true),
                    IdStydy = table.Column<int>(type: "int", nullable: true),
                    AnamnesisDisease = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnamnesisLife = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Complaints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatmentPlan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reception", x => x.IdReception);
                    table.ForeignKey(
                        name: "FK_Reception_Analyze_IdAnalyze",
                        column: x => x.IdAnalyze,
                        principalTable: "Analyze",
                        principalColumn: "IdAnalyzes");
                    table.ForeignKey(
                        name: "FK_Reception_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reception_Departament_IdDepartament",
                        column: x => x.IdDepartament,
                        principalTable: "Departament",
                        principalColumn: "IdDepartament");
                    table.ForeignKey(
                        name: "FK_Reception_Doctor_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IdDoctor");
                    table.ForeignKey(
                        name: "FK_Reception_Service_IdService",
                        column: x => x.IdService,
                        principalTable: "Service",
                        principalColumn: "IdService");
                    table.ForeignKey(
                        name: "FK_Reception_Stydy_IdStydy",
                        column: x => x.IdStydy,
                        principalTable: "Stydy",
                        principalColumn: "IdStydy");
                });

            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    IdHospital = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDepartament = table.Column<int>(type: "int", nullable: true),
                    IdOperation = table.Column<int>(type: "int", nullable: true),
                    IdOrganization = table.Column<int>(type: "int", nullable: true),
                    IdReception = table.Column<int>(type: "int", nullable: true),
                    InspectionHospitalId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateDischarge = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateReceipt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ward = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.IdHospital);
                    table.ForeignKey(
                        name: "FK_Hospital_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hospital_Departament_IdDepartament",
                        column: x => x.IdDepartament,
                        principalTable: "Departament",
                        principalColumn: "IdDepartament");
                    table.ForeignKey(
                        name: "FK_Hospital_InspectionHospital_InspectionHospitalId",
                        column: x => x.InspectionHospitalId,
                        principalTable: "InspectionHospital",
                        principalColumn: "IdInspectionHospital");
                    table.ForeignKey(
                        name: "FK_Hospital_Operation_IdOperation",
                        column: x => x.IdOperation,
                        principalTable: "Operation",
                        principalColumn: "IdOperation");
                    table.ForeignKey(
                        name: "FK_Hospital_Organization_IdOrganization",
                        column: x => x.IdOrganization,
                        principalTable: "Organization",
                        principalColumn: "IdOrganization");
                    table.ForeignKey(
                        name: "FK_Hospital_Reception_IdReception",
                        column: x => x.IdReception,
                        principalTable: "Reception",
                        principalColumn: "IdReception");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Polyclinic_IdAnalyze",
                table: "Polyclinic",
                column: "IdAnalyze");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_IdDepartament",
                table: "Hospital",
                column: "IdDepartament");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_IdOperation",
                table: "Hospital",
                column: "IdOperation");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_IdOrganization",
                table: "Hospital",
                column: "IdOrganization");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_IdReception",
                table: "Hospital",
                column: "IdReception");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_InspectionHospitalId",
                table: "Hospital",
                column: "InspectionHospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_UserId",
                table: "Hospital",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionHospital_IdDepartament",
                table: "InspectionHospital",
                column: "IdDepartament");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionHospital_IdDoctor",
                table: "InspectionHospital",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionHospital_IdService",
                table: "InspectionHospital",
                column: "IdService");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionHospital_UserId",
                table: "InspectionHospital",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionPoliclinics_IdDepartament",
                table: "InspectionPoliclinics",
                column: "IdDepartament");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionPoliclinics_IdDoctor",
                table: "InspectionPoliclinics",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionPoliclinics_IdService",
                table: "InspectionPoliclinics",
                column: "IdService");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionPoliclinics_UserId",
                table: "InspectionPoliclinics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reception_ApplicationUserId",
                table: "Reception",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reception_IdAnalyze",
                table: "Reception",
                column: "IdAnalyze");

            migrationBuilder.CreateIndex(
                name: "IX_Reception_IdDepartament",
                table: "Reception",
                column: "IdDepartament");

            migrationBuilder.CreateIndex(
                name: "IX_Reception_IdDoctor",
                table: "Reception",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Reception_IdService",
                table: "Reception",
                column: "IdService");

            migrationBuilder.CreateIndex(
                name: "IX_Reception_IdStydy",
                table: "Reception",
                column: "IdStydy");

            migrationBuilder.AddForeignKey(
                name: "FK_Polyclinic_Analyze_IdAnalyze",
                table: "Polyclinic",
                column: "IdAnalyze",
                principalTable: "Analyze",
                principalColumn: "IdAnalyzes");

            migrationBuilder.AddForeignKey(
                name: "FK_Polyclinic_InspectionPoliclinics_InspectionPolyclinicId",
                table: "Polyclinic",
                column: "InspectionPolyclinicId",
                principalTable: "InspectionPoliclinics",
                principalColumn: "IdInspectionPoliclinic");

            migrationBuilder.AddForeignKey(
                name: "FK_Polyclinic_Stydy_IdStydy",
                table: "Polyclinic",
                column: "IdStydy",
                principalTable: "Stydy",
                principalColumn: "IdStydy");
        }
    }
}
