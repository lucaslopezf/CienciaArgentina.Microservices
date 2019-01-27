using Microsoft.EntityFrameworkCore.Migrations;

namespace CienciaArgentina.Microservices.Data.Migrations
{
    public partial class modifyUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_IdRole1",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersData_IdUserData1",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "IdUserData1",
                table: "Users",
                newName: "UserDataIdUserData");

            migrationBuilder.RenameColumn(
                name: "IdRole1",
                table: "Users",
                newName: "RolIdRole");

            migrationBuilder.RenameIndex(
                name: "IX_Users_IdUserData1",
                table: "Users",
                newName: "IX_Users_UserDataIdUserData");

            migrationBuilder.RenameIndex(
                name: "IX_Users_IdRole1",
                table: "Users",
                newName: "IX_Users_RolIdRole");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RolIdRole",
                table: "Users",
                column: "RolIdRole",
                principalTable: "Roles",
                principalColumn: "IdRole",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersData_UserDataIdUserData",
                table: "Users",
                column: "UserDataIdUserData",
                principalTable: "UsersData",
                principalColumn: "IdUserData",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolIdRole",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersData_UserDataIdUserData",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserDataIdUserData",
                table: "Users",
                newName: "IdUserData1");

            migrationBuilder.RenameColumn(
                name: "RolIdRole",
                table: "Users",
                newName: "IdRole1");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserDataIdUserData",
                table: "Users",
                newName: "IX_Users_IdUserData1");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RolIdRole",
                table: "Users",
                newName: "IX_Users_IdRole1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_IdRole1",
                table: "Users",
                column: "IdRole1",
                principalTable: "Roles",
                principalColumn: "IdRole",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersData_IdUserData1",
                table: "Users",
                column: "IdUserData1",
                principalTable: "UsersData",
                principalColumn: "IdUserData",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
