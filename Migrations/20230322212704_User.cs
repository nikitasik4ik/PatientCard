using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientCard.Migrations
{
    /// <inheritdoc />
    public partial class User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisabilitySheet",
                columns: table => new
                {
                    DisabilitySheetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdDoctor = table.Column<int>(type: "int", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdDepartement = table.Column<int>(type: "int", nullable: true),
                    DateOfSinging = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisabilitySheet", x => x.DisabilitySheetId);
                    table.ForeignKey(
                        name: "FK_DisabilitySheet_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Financing",
                columns: table => new
                {
                    FinancingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinancingName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financing", x => x.FinancingId);
                });

            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    HospitalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DepartamentId = table.Column<int>(type: "int", nullable: true),
                    ReceptionId = table.Column<int>(type: "int", nullable: true),
                    InspectionHospitalId = table.Column<int>(type: "int", nullable: true),
                    DateReceipt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDischarge = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ward = table.Column<int>(type: "int", nullable: true),
                    DoctorHospitalId = table.Column<int>(type: "int", nullable: true),
                    OperationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.HospitalId);
                    table.ForeignKey(
                        name: "FK_Hospital_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InspectionHospital",
                columns: table => new
                {
                    InspectionHospitalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DepartamentId = table.Column<int>(type: "int", nullable: true),
                    DoctorHospitalId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    InspectionPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complaint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inspection = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionHospital", x => x.InspectionHospitalId);
                    table.ForeignKey(
                        name: "FK_InspectionHospital_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InspectionPoliclinics",
                columns: table => new
                {
                    InspectionPoliclinicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    Complaints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnamnesisDisease = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recommendation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionPoliclinics", x => x.InspectionPoliclinicId);
                    table.ForeignKey(
                        name: "FK_InspectionPoliclinics_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicalCar",
                columns: table => new
                {
                    MedicalCarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateMedicalCar = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceExit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonExit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultExit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssueExit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDoctor = table.Column<int>(type: "int", nullable: true),
                    IdDoctorNavigationIdDoctor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCar", x => x.MedicalCarId);
                    table.ForeignKey(
                        name: "FK_MedicalCar_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicalCar_Doctor_IdDoctorNavigationIdDoctor",
                        column: x => x.IdDoctorNavigationIdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IdDoctor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    OperationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateOperation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdDepartamnet = table.Column<int>(type: "int", nullable: true),
                    DiagnosisOperation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdService = table.Column<int>(type: "int", nullable: true),
                    DurationOperation = table.Column<TimeSpan>(type: "time", nullable: true),
                    ProtocolOperation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdFinancing = table.Column<int>(type: "int", nullable: true),
                    IdDoctorHospital = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.OperationId);
                    table.ForeignKey(
                        name: "FK_Operation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartamentId = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.OrganizationId);
                    table.ForeignKey(
                        name: "FK_Organization_Departament_DepartamentId",
                        column: x => x.DepartamentId,
                        principalTable: "Departament",
                        principalColumn: "IdDepartament");
                    table.ForeignKey(
                        name: "FK_Organization_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "IdDoctor");
                });

            migrationBuilder.CreateTable(
                name: "Polyclinic",
                columns: table => new
                {
                    PolyclinicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartamentId = table.Column<int>(type: "int", nullable: true),
                    Complaints = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InspectionId = table.Column<int>(type: "int", nullable: true),
                    FinancingId = table.Column<int>(type: "int", nullable: true),
                    Conditions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnalyzeId = table.Column<int>(type: "int", nullable: true),
                    StudyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polyclinic", x => x.PolyclinicId);
                    table.ForeignKey(
                        name: "FK_Polyclinic_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reception",
                columns: table => new
                {
                    ReceptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartamentId = table.Column<int>(type: "int", nullable: true),
                    DoctorHospitalId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complaints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalyzeId = table.Column<int>(type: "int", nullable: true),
                    StudyId = table.Column<int>(type: "int", nullable: true),
                    TreatmentPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnamnesisDisease = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnamnesisLife = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reception", x => x.ReceptionId);
                    table.ForeignKey(
                        name: "FK_Reception_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeRecipe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRecipe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdDoctor = table.Column<int>(type: "int", nullable: true),
                    RecipeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.RecipeId);
                    table.ForeignKey(
                        name: "FK_Recipe_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    IdService = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameService = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeService = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.IdService);
                });

            migrationBuilder.CreateTable(
                name: "Stydy",
                columns: table => new
                {
                    StydyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartamentId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Done = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Protocol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conclusion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stydy", x => x.StydyId);
                    table.ForeignKey(
                        name: "FK_Stydy_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisabilitySheet_UserId",
                table: "DisabilitySheet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_UserId",
                table: "Hospital",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionHospital_UserId",
                table: "InspectionHospital",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionPoliclinics_UserId",
                table: "InspectionPoliclinics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCar_IdDoctorNavigationIdDoctor",
                table: "MedicalCar",
                column: "IdDoctorNavigationIdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCar_UserId",
                table: "MedicalCar",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_UserId",
                table: "Operation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_DepartamentId",
                table: "Organization",
                column: "DepartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_DoctorId",
                table: "Organization",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Polyclinic_UserId",
                table: "Polyclinic",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reception_ApplicationUserId",
                table: "Reception",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_UserId",
                table: "Recipe",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stydy_UserId",
                table: "Stydy",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisabilitySheet");

            migrationBuilder.DropTable(
                name: "Financing");

            migrationBuilder.DropTable(
                name: "Hospital");

            migrationBuilder.DropTable(
                name: "InspectionHospital");

            migrationBuilder.DropTable(
                name: "InspectionPoliclinics");

            migrationBuilder.DropTable(
                name: "MedicalCar");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "Polyclinic");

            migrationBuilder.DropTable(
                name: "Reception");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Stydy");
        }
    }
}
