using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CienciaArgentina.Microservices.Data.Migrations
{
    public partial class modifyJobOfferCandidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "JobOfferCandidates",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_JobOfferCandidates_UserId",
                table: "JobOfferCandidates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOfferCandidates_AspNetUsers_UserId",
                table: "JobOfferCandidates",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOfferCandidates_AspNetUsers_UserId",
                table: "JobOfferCandidates");

            migrationBuilder.DropIndex(
                name: "IX_JobOfferCandidates_UserId",
                table: "JobOfferCandidates");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "JobOfferCandidates",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
