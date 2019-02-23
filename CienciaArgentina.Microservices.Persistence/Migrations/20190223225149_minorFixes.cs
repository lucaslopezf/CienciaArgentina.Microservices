using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CienciaArgentina.Microservices.Data.Migrations
{
    public partial class minorFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersData",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "JobOfferCandidateReferrals",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_UsersData_UserId",
                table: "UsersData",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfferCandidateReferrals_UserId",
                table: "JobOfferCandidateReferrals",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOfferCandidateReferrals_AspNetUsers_UserId",
                table: "JobOfferCandidateReferrals",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersData_AspNetUsers_UserId",
                table: "UsersData",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOfferCandidateReferrals_AspNetUsers_UserId",
                table: "JobOfferCandidateReferrals");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersData_AspNetUsers_UserId",
                table: "UsersData");

            migrationBuilder.DropIndex(
                name: "IX_UsersData_UserId",
                table: "UsersData");

            migrationBuilder.DropIndex(
                name: "IX_JobOfferCandidateReferrals_UserId",
                table: "JobOfferCandidateReferrals");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UsersData",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "JobOfferCandidateReferrals",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
