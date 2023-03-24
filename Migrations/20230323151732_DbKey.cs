using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientCard.Migrations
{
    /// <inheritdoc />
    public partial class DbKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departament",
                columns: table => new
                {
                    IdDepartament = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameDepartament = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeDepartament = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdressDepartament = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departament", x => x.IdDepartament);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullNameDoctor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignatureDoctor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Financing",
                columns: table => new
                {
                    IdFinancing = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinancingName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financing", x => x.IdFinancing);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    IdService = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameService = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeService = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.IdService);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Anthropometry",
                columns: table => new
                {
                    AnthropometryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anthropometry", x => x.AnthropometryId);
                    table.ForeignKey(
                        name: "FK_Anthropometry_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Glucose",
                columns: table => new
                {
                    GlucoseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glucose", x => x.GlucoseId);
                    table.ForeignKey(
                        name: "FK_Glucose_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Oxygen",
                columns: table => new
                {
                    OxygenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oxygen", x => x.OxygenId);
                    table.ForeignKey(
                        name: "FK_Oxygen_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pressure",
                columns: table => new
                {
                    PressureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pressure", x => x.PressureId);
                    table.ForeignKey(
                        name: "FK_Pressure_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Temperature",
                columns: table => new
                {
                    TemperatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperature", x => x.TemperatureId);
                    table.ForeignKey(
                        name: "FK_Temperature_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicalCar",
                columns: table => new
                {
                    IdMedicalCar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateMedicalCar = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceExit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonExit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultExit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssueExit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDoctor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCar", x => x.IdMedicalCar);
                    table.ForeignKey(
                        name: "FK_MedicalCar_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicalCar_Doctor_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IdDoctor");
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    IdOrganization = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDepartament = table.Column<int>(type: "int", nullable: true),
                    IdDoctor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.IdOrganization);
                    table.ForeignKey(
                        name: "FK_Organization_Departament_IdDepartament",
                        column: x => x.IdDepartament,
                        principalTable: "Departament",
                        principalColumn: "IdDepartament");
                    table.ForeignKey(
                        name: "FK_Organization_Doctor_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IdDoctor");
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    IdRecipe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeRecipe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRecipe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdDoctor = table.Column<int>(type: "int", nullable: true),
                    RecipeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.IdRecipe);
                    table.ForeignKey(
                        name: "FK_Recipe_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recipe_Doctor_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IdDoctor");
                });

            migrationBuilder.CreateTable(
                name: "InspectionHospital",
                columns: table => new
                {
                    IdInspectionHospital = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdDepartament = table.Column<int>(type: "int", nullable: true),
                    IdDoctor = table.Column<int>(type: "int", nullable: true),
                    IdService = table.Column<int>(type: "int", nullable: true),
                    InspectionPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complaint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inspection = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdDepartament = table.Column<int>(type: "int", nullable: true),
                    IdDoctor = table.Column<int>(type: "int", nullable: true),
                    IdService = table.Column<int>(type: "int", nullable: true),
                    Complaints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnamnesisDisease = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Analyze",
                columns: table => new
                {
                    IdAnalyzes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDepartament = table.Column<int>(type: "int", nullable: true),
                    IdOrganization = table.Column<int>(type: "int", nullable: true),
                    IdService = table.Column<int>(type: "int", nullable: true),
                    DateAnalyzes = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdDoctor = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analyze", x => x.IdAnalyzes);
                    table.ForeignKey(
                        name: "FK_Analyze_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Analyze_Departament_IdDepartament",
                        column: x => x.IdDepartament,
                        principalTable: "Departament",
                        principalColumn: "IdDepartament");
                    table.ForeignKey(
                        name: "FK_Analyze_Doctor_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IdDoctor");
                    table.ForeignKey(
                        name: "FK_Analyze_Organization_IdOrganization",
                        column: x => x.IdOrganization,
                        principalTable: "Organization",
                        principalColumn: "IdOrganization");
                    table.ForeignKey(
                        name: "FK_Analyze_Service_IdService",
                        column: x => x.IdService,
                        principalTable: "Service",
                        principalColumn: "IdService");
                });

            migrationBuilder.CreateTable(
                name: "DisabilitySheet",
                columns: table => new
                {
                    IdDisabilitySheet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdDoctor = table.Column<int>(type: "int", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdDepartament = table.Column<int>(type: "int", nullable: true),
                    IdOrganozatiom = table.Column<int>(type: "int", nullable: true),
                    IdOrganization = table.Column<int>(type: "int", nullable: true),
                    DateOfSinging = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisabilitySheet", x => x.IdDisabilitySheet);
                    table.ForeignKey(
                        name: "FK_DisabilitySheet_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DisabilitySheet_Departament_IdDepartament",
                        column: x => x.IdDepartament,
                        principalTable: "Departament",
                        principalColumn: "IdDepartament");
                    table.ForeignKey(
                        name: "FK_DisabilitySheet_Doctor_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IdDoctor");
                    table.ForeignKey(
                        name: "FK_DisabilitySheet_Organization_IdOrganization",
                        column: x => x.IdOrganization,
                        principalTable: "Organization",
                        principalColumn: "IdOrganization");
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    IdOperation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateOperation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdDepartament = table.Column<int>(type: "int", nullable: true),
                    IdOrganozation = table.Column<int>(type: "int", nullable: true),
                    IdOrganization = table.Column<int>(type: "int", nullable: true),
                    DiagnosisOperation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdService = table.Column<int>(type: "int", nullable: true),
                    DurationOperation = table.Column<TimeSpan>(type: "time", nullable: true),
                    ProtocolOperation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdFinancing = table.Column<int>(type: "int", nullable: true),
                    IdDoctor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.IdOperation);
                    table.ForeignKey(
                        name: "FK_Operation_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Operation_Departament_IdDepartament",
                        column: x => x.IdDepartament,
                        principalTable: "Departament",
                        principalColumn: "IdDepartament");
                    table.ForeignKey(
                        name: "FK_Operation_Doctor_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IdDoctor");
                    table.ForeignKey(
                        name: "FK_Operation_Financing_IdFinancing",
                        column: x => x.IdFinancing,
                        principalTable: "Financing",
                        principalColumn: "IdFinancing");
                    table.ForeignKey(
                        name: "FK_Operation_Organization_IdOrganization",
                        column: x => x.IdOrganization,
                        principalTable: "Organization",
                        principalColumn: "IdOrganization");
                    table.ForeignKey(
                        name: "FK_Operation_Service_IdService",
                        column: x => x.IdService,
                        principalTable: "Service",
                        principalColumn: "IdService");
                });

            migrationBuilder.CreateTable(
                name: "Stydy",
                columns: table => new
                {
                    IdStydy = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDepartament = table.Column<int>(type: "int", nullable: true),
                    IdOrganozation = table.Column<int>(type: "int", nullable: true),
                    IdOrganization = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Done = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Protocol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conclusion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDoctor = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stydy", x => x.IdStydy);
                    table.ForeignKey(
                        name: "FK_Stydy_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stydy_Departament_IdDepartament",
                        column: x => x.IdDepartament,
                        principalTable: "Departament",
                        principalColumn: "IdDepartament");
                    table.ForeignKey(
                        name: "FK_Stydy_Doctor_IdDoctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IdDoctor");
                    table.ForeignKey(
                        name: "FK_Stydy_Organization_IdOrganization",
                        column: x => x.IdOrganization,
                        principalTable: "Organization",
                        principalColumn: "IdOrganization");
                });

            migrationBuilder.CreateTable(
                name: "Polyclinic",
                columns: table => new
                {
                    IdPolyclinic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdDepartament = table.Column<int>(type: "int", nullable: true),
                    IdOrganozation = table.Column<int>(type: "int", nullable: true),
                    IdOrganization = table.Column<int>(type: "int", nullable: true),
                    Complaints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InspectionId = table.Column<int>(type: "int", nullable: true),
                    InspectionPolyclinicIdInspectionPoliclinic = table.Column<int>(type: "int", nullable: true),
                    IdFinancing = table.Column<int>(type: "int", nullable: true),
                    Conditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdAnalyze = table.Column<int>(type: "int", nullable: true),
                    IdStydy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polyclinic", x => x.IdPolyclinic);
                    table.ForeignKey(
                        name: "FK_Polyclinic_Analyze_IdAnalyze",
                        column: x => x.IdAnalyze,
                        principalTable: "Analyze",
                        principalColumn: "IdAnalyzes");
                    table.ForeignKey(
                        name: "FK_Polyclinic_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Polyclinic_Departament_IdDepartament",
                        column: x => x.IdDepartament,
                        principalTable: "Departament",
                        principalColumn: "IdDepartament");
                    table.ForeignKey(
                        name: "FK_Polyclinic_Financing_IdFinancing",
                        column: x => x.IdFinancing,
                        principalTable: "Financing",
                        principalColumn: "IdFinancing");
                    table.ForeignKey(
                        name: "FK_Polyclinic_InspectionPoliclinics_InspectionPolyclinicIdInspectionPoliclinic",
                        column: x => x.InspectionPolyclinicIdInspectionPoliclinic,
                        principalTable: "InspectionPoliclinics",
                        principalColumn: "IdInspectionPoliclinic");
                    table.ForeignKey(
                        name: "FK_Polyclinic_Organization_IdOrganization",
                        column: x => x.IdOrganization,
                        principalTable: "Organization",
                        principalColumn: "IdOrganization");
                    table.ForeignKey(
                        name: "FK_Polyclinic_Stydy_IdStydy",
                        column: x => x.IdStydy,
                        principalTable: "Stydy",
                        principalColumn: "IdStydy");
                });

            migrationBuilder.CreateTable(
                name: "Reception",
                columns: table => new
                {
                    IdReception = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdDepartament = table.Column<int>(type: "int", nullable: true),
                    IdDoctor = table.Column<int>(type: "int", nullable: true),
                    IdService = table.Column<int>(type: "int", nullable: true),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complaints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdAnalyze = table.Column<int>(type: "int", nullable: true),
                    IdStydy = table.Column<int>(type: "int", nullable: true),
                    TreatmentPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnamnesisDisease = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnamnesisLife = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdDepartament = table.Column<int>(type: "int", nullable: true),
                    IdOrganozatiom = table.Column<int>(type: "int", nullable: true),
                    IdOrganization = table.Column<int>(type: "int", nullable: true),
                    IdReception = table.Column<int>(type: "int", nullable: true),
                    InspectionHospitalId = table.Column<int>(type: "int", nullable: true),
                    DateReceipt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDischarge = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ward = table.Column<int>(type: "int", nullable: true),
                    IdOperation = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_Analyze_IdDepartament",
                table: "Analyze",
                column: "IdDepartament");

            migrationBuilder.CreateIndex(
                name: "IX_Analyze_IdDoctor",
                table: "Analyze",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Analyze_IdOrganization",
                table: "Analyze",
                column: "IdOrganization");

            migrationBuilder.CreateIndex(
                name: "IX_Analyze_IdService",
                table: "Analyze",
                column: "IdService");

            migrationBuilder.CreateIndex(
                name: "IX_Analyze_UserId",
                table: "Analyze",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Anthropometry_UserId",
                table: "Anthropometry",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DisabilitySheet_IdDepartament",
                table: "DisabilitySheet",
                column: "IdDepartament");

            migrationBuilder.CreateIndex(
                name: "IX_DisabilitySheet_IdDoctor",
                table: "DisabilitySheet",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_DisabilitySheet_IdOrganization",
                table: "DisabilitySheet",
                column: "IdOrganization");

            migrationBuilder.CreateIndex(
                name: "IX_DisabilitySheet_UserId",
                table: "DisabilitySheet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Glucose_UserId",
                table: "Glucose",
                column: "UserId");

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
                name: "IX_MedicalCar_IdDoctor",
                table: "MedicalCar",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCar_UserId",
                table: "MedicalCar",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_IdDepartament",
                table: "Operation",
                column: "IdDepartament");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_IdDoctor",
                table: "Operation",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_IdFinancing",
                table: "Operation",
                column: "IdFinancing");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_IdOrganization",
                table: "Operation",
                column: "IdOrganization");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_IdService",
                table: "Operation",
                column: "IdService");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_UserId",
                table: "Operation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_IdDepartament",
                table: "Organization",
                column: "IdDepartament");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_IdDoctor",
                table: "Organization",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Oxygen_UserId",
                table: "Oxygen",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Polyclinic_IdAnalyze",
                table: "Polyclinic",
                column: "IdAnalyze");

            migrationBuilder.CreateIndex(
                name: "IX_Polyclinic_IdDepartament",
                table: "Polyclinic",
                column: "IdDepartament");

            migrationBuilder.CreateIndex(
                name: "IX_Polyclinic_IdFinancing",
                table: "Polyclinic",
                column: "IdFinancing");

            migrationBuilder.CreateIndex(
                name: "IX_Polyclinic_IdOrganization",
                table: "Polyclinic",
                column: "IdOrganization");

            migrationBuilder.CreateIndex(
                name: "IX_Polyclinic_IdStydy",
                table: "Polyclinic",
                column: "IdStydy");

            migrationBuilder.CreateIndex(
                name: "IX_Polyclinic_InspectionPolyclinicIdInspectionPoliclinic",
                table: "Polyclinic",
                column: "InspectionPolyclinicIdInspectionPoliclinic");

            migrationBuilder.CreateIndex(
                name: "IX_Polyclinic_UserId",
                table: "Polyclinic",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pressure_UserId",
                table: "Pressure",
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

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_IdDoctor",
                table: "Recipe",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_UserId",
                table: "Recipe",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stydy_IdDepartament",
                table: "Stydy",
                column: "IdDepartament");

            migrationBuilder.CreateIndex(
                name: "IX_Stydy_IdDoctor",
                table: "Stydy",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Stydy_IdOrganization",
                table: "Stydy",
                column: "IdOrganization");

            migrationBuilder.CreateIndex(
                name: "IX_Stydy_UserId",
                table: "Stydy",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Temperature_UserId",
                table: "Temperature",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anthropometry");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DisabilitySheet");

            migrationBuilder.DropTable(
                name: "Glucose");

            migrationBuilder.DropTable(
                name: "Hospital");

            migrationBuilder.DropTable(
                name: "MedicalCar");

            migrationBuilder.DropTable(
                name: "Oxygen");

            migrationBuilder.DropTable(
                name: "Polyclinic");

            migrationBuilder.DropTable(
                name: "Pressure");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "Temperature");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "InspectionHospital");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "Reception");

            migrationBuilder.DropTable(
                name: "InspectionPoliclinics");

            migrationBuilder.DropTable(
                name: "Financing");

            migrationBuilder.DropTable(
                name: "Analyze");

            migrationBuilder.DropTable(
                name: "Stydy");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "Departament");

            migrationBuilder.DropTable(
                name: "Doctor");
        }
    }
}
