using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CienciaArgentina.Microservices.Data.Migrations
{
    public partial class ChangesInUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UsersData_UserDataId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserDataId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserDataId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "UsersData",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "UsersData",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UsersData",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UsersData");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "UsersData",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "UsersData",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AddColumn<int>(
                name: "UserDataId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserDataId",
                table: "AspNetUsers",
                column: "UserDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UsersData_UserDataId",
                table: "AspNetUsers",
                column: "UserDataId",
                principalTable: "UsersData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
