using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CienciaArgentina.Microservices.Data.Migrations
{
    public partial class NulleableDeleteDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "WorkExperience",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "UserStudyTypes",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "UserStudiesCompletion",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "UserStudies",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "UserLaboratories",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "UserInstitutes",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "Universities",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "States",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "SocialNetworks",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "Sex",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "Positions",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "Localities",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "Laboratories",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "Institutes",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "Countries",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "Cities",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "Addresses",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "WorkExperience",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "UserStudyTypes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "UserStudiesCompletion",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "UserStudies",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "UserLaboratories",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "UserInstitutes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "Universities",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "States",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "SocialNetworks",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "Sex",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "Positions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "Localities",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "Laboratories",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "Institutes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "Cities",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
