using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientCard.Migrations
{
    /// <inheritdoc />
    public partial class Gender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polyclinic_InspectionPoliclinics_InspectionPolyclinicIdInspectionPoliclinic",
                table: "Polyclinic");

            migrationBuilder.DropColumn(
                name: "InspectionId",
                table: "Polyclinic");

            migrationBuilder.DropColumn(
                name: "IdOrganozatiom",
                table: "DisabilitySheet");

            migrationBuilder.RenameColumn(
                name: "InspectionPolyclinicIdInspectionPoliclinic",
                table: "Polyclinic",
                newName: "InspectionPolyclinicId");

            migrationBuilder.RenameIndex(
                name: "IX_Polyclinic_InspectionPolyclinicIdInspectionPoliclinic",
                table: "Polyclinic",
                newName: "IX_Polyclinic_InspectionPolyclinicId");

            migrationBuilder.RenameColumn(
                name: "IdOrganozatiom",
                table: "Hospital",
                newName: "IdOrganozation");

            migrationBuilder.AddColumn<string>(
                name: "AdressReg",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdressRes",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GenderName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PassportSeries",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Patronymic",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceWork",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Polisy",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Snils",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Polyclinic_InspectionPoliclinics_InspectionPolyclinicId",
                table: "Polyclinic",
                column: "InspectionPolyclinicId",
                principalTable: "InspectionPoliclinics",
                principalColumn: "IdInspectionPoliclinic");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polyclinic_InspectionPoliclinics_InspectionPolyclinicId",
                table: "Polyclinic");

            migrationBuilder.DropColumn(
                name: "AdressReg",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AdressRes",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DataBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GenderName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PassportSeries",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Patronymic",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PlaceWork",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Polisy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Snils",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "InspectionPolyclinicId",
                table: "Polyclinic",
                newName: "InspectionPolyclinicIdInspectionPoliclinic");

            migrationBuilder.RenameIndex(
                name: "IX_Polyclinic_InspectionPolyclinicId",
                table: "Polyclinic",
                newName: "IX_Polyclinic_InspectionPolyclinicIdInspectionPoliclinic");

            migrationBuilder.RenameColumn(
                name: "IdOrganozation",
                table: "Hospital",
                newName: "IdOrganozatiom");

            migrationBuilder.AddColumn<int>(
                name: "InspectionId",
                table: "Polyclinic",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdOrganozatiom",
                table: "DisabilitySheet",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Polyclinic_InspectionPoliclinics_InspectionPolyclinicIdInspectionPoliclinic",
                table: "Polyclinic",
                column: "InspectionPolyclinicIdInspectionPoliclinic",
                principalTable: "InspectionPoliclinics",
                principalColumn: "IdInspectionPoliclinic");
        }
    }
}
