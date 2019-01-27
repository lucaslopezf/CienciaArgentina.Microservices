using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CienciaArgentina.Microservices.Data.Migrations
{
    public partial class modifyDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialNetworks_Users_IdUser1",
                table: "SocialNetworks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInstitutes_Roles_IdRole1",
                table: "UserInstitutes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInstitutes_Users_IdUser1",
                table: "UserInstitutes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserKeys_Users_IdUser1",
                table: "UserKeys");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLaboratories_Roles_IdRole1",
                table: "UserLaboratories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLaboratories_Users_IdUser1",
                table: "UserLaboratories");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolIdRole",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersData_UserDataIdUserData",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStudies_UsersData_IdUserData1",
                table: "UserStudies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserLaboratories_IdUser1",
                table: "UserLaboratories");

            migrationBuilder.DropIndex(
                name: "IX_UserKeys_IdUser1",
                table: "UserKeys");

            migrationBuilder.DropIndex(
                name: "IX_UserInstitutes_IdUser1",
                table: "UserInstitutes");

            migrationBuilder.DropIndex(
                name: "IX_SocialNetworks_IdUser1",
                table: "SocialNetworks");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdUser1",
                table: "UserLaboratories");

            migrationBuilder.DropColumn(
                name: "IdUser1",
                table: "UserKeys");

            migrationBuilder.DropColumn(
                name: "IdUser1",
                table: "UserInstitutes");

            migrationBuilder.DropColumn(
                name: "IdUser1",
                table: "SocialNetworks");

            migrationBuilder.RenameColumn(
                name: "IdUserData1",
                table: "UserStudies",
                newName: "IdUserDataId");

            migrationBuilder.RenameIndex(
                name: "IX_UserStudies_IdUserData1",
                table: "UserStudies",
                newName: "IX_UserStudies_IdUserDataId");

            migrationBuilder.RenameColumn(
                name: "IdUserData",
                table: "UsersData",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserDataIdUserData",
                table: "Users",
                newName: "UserDataId");

            migrationBuilder.RenameColumn(
                name: "RolIdRole",
                table: "Users",
                newName: "RolId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserDataIdUserData",
                table: "Users",
                newName: "IX_Users_UserDataId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RolIdRole",
                table: "Users",
                newName: "IX_Users_RolId");

            migrationBuilder.RenameColumn(
                name: "IdRole1",
                table: "UserLaboratories",
                newName: "IdUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLaboratories_IdRole1",
                table: "UserLaboratories",
                newName: "IX_UserLaboratories_IdUserId");

            migrationBuilder.RenameColumn(
                name: "IdRole1",
                table: "UserInstitutes",
                newName: "IdUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserInstitutes_IdRole1",
                table: "UserInstitutes",
                newName: "IX_UserInstitutes_IdUserId");

            migrationBuilder.RenameColumn(
                name: "IdRole",
                table: "Roles",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "IdRoleId",
                table: "UserLaboratories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUserId",
                table: "UserKeys",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdRoleId",
                table: "UserInstitutes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUserId",
                table: "SocialNetworks",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserLaboratories_IdRoleId",
                table: "UserLaboratories",
                column: "IdRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserKeys_IdUserId",
                table: "UserKeys",
                column: "IdUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInstitutes_IdRoleId",
                table: "UserInstitutes",
                column: "IdRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetworks_IdUserId",
                table: "SocialNetworks",
                column: "IdUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialNetworks_Users_IdUserId",
                table: "SocialNetworks",
                column: "IdUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInstitutes_Roles_IdRoleId",
                table: "UserInstitutes",
                column: "IdRoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInstitutes_Users_IdUserId",
                table: "UserInstitutes",
                column: "IdUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserKeys_Users_IdUserId",
                table: "UserKeys",
                column: "IdUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLaboratories_Roles_IdRoleId",
                table: "UserLaboratories",
                column: "IdRoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLaboratories_Users_IdUserId",
                table: "UserLaboratories",
                column: "IdUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RolId",
                table: "Users",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersData_UserDataId",
                table: "Users",
                column: "UserDataId",
                principalTable: "UsersData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStudies_UsersData_IdUserDataId",
                table: "UserStudies",
                column: "IdUserDataId",
                principalTable: "UsersData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialNetworks_Users_IdUserId",
                table: "SocialNetworks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInstitutes_Roles_IdRoleId",
                table: "UserInstitutes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInstitutes_Users_IdUserId",
                table: "UserInstitutes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserKeys_Users_IdUserId",
                table: "UserKeys");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLaboratories_Roles_IdRoleId",
                table: "UserLaboratories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLaboratories_Users_IdUserId",
                table: "UserLaboratories");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersData_UserDataId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStudies_UsersData_IdUserDataId",
                table: "UserStudies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserLaboratories_IdRoleId",
                table: "UserLaboratories");

            migrationBuilder.DropIndex(
                name: "IX_UserKeys_IdUserId",
                table: "UserKeys");

            migrationBuilder.DropIndex(
                name: "IX_UserInstitutes_IdRoleId",
                table: "UserInstitutes");

            migrationBuilder.DropIndex(
                name: "IX_SocialNetworks_IdUserId",
                table: "SocialNetworks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdRoleId",
                table: "UserLaboratories");

            migrationBuilder.DropColumn(
                name: "IdUserId",
                table: "UserKeys");

            migrationBuilder.DropColumn(
                name: "IdRoleId",
                table: "UserInstitutes");

            migrationBuilder.DropColumn(
                name: "IdUserId",
                table: "SocialNetworks");

            migrationBuilder.RenameColumn(
                name: "IdUserDataId",
                table: "UserStudies",
                newName: "IdUserData1");

            migrationBuilder.RenameIndex(
                name: "IX_UserStudies_IdUserDataId",
                table: "UserStudies",
                newName: "IX_UserStudies_IdUserData1");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UsersData",
                newName: "IdUserData");

            migrationBuilder.RenameColumn(
                name: "UserDataId",
                table: "Users",
                newName: "UserDataIdUserData");

            migrationBuilder.RenameColumn(
                name: "RolId",
                table: "Users",
                newName: "RolIdRole");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserDataId",
                table: "Users",
                newName: "IX_Users_UserDataIdUserData");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RolId",
                table: "Users",
                newName: "IX_Users_RolIdRole");

            migrationBuilder.RenameColumn(
                name: "IdUserId",
                table: "UserLaboratories",
                newName: "IdRole1");

            migrationBuilder.RenameIndex(
                name: "IX_UserLaboratories_IdUserId",
                table: "UserLaboratories",
                newName: "IX_UserLaboratories_IdRole1");

            migrationBuilder.RenameColumn(
                name: "IdUserId",
                table: "UserInstitutes",
                newName: "IdRole1");

            migrationBuilder.RenameIndex(
                name: "IX_UserInstitutes_IdUserId",
                table: "UserInstitutes",
                newName: "IX_UserInstitutes_IdRole1");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Roles",
                newName: "IdRole");

            migrationBuilder.AddColumn<Guid>(
                name: "IdUser",
                table: "Users",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdUser1",
                table: "UserLaboratories",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdUser1",
                table: "UserKeys",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdUser1",
                table: "UserInstitutes",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdUser1",
                table: "SocialNetworks",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserLaboratories_IdUser1",
                table: "UserLaboratories",
                column: "IdUser1");

            migrationBuilder.CreateIndex(
                name: "IX_UserKeys_IdUser1",
                table: "UserKeys",
                column: "IdUser1");

            migrationBuilder.CreateIndex(
                name: "IX_UserInstitutes_IdUser1",
                table: "UserInstitutes",
                column: "IdUser1");

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetworks_IdUser1",
                table: "SocialNetworks",
                column: "IdUser1");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialNetworks_Users_IdUser1",
                table: "SocialNetworks",
                column: "IdUser1",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInstitutes_Roles_IdRole1",
                table: "UserInstitutes",
                column: "IdRole1",
                principalTable: "Roles",
                principalColumn: "IdRole",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInstitutes_Users_IdUser1",
                table: "UserInstitutes",
                column: "IdUser1",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserKeys_Users_IdUser1",
                table: "UserKeys",
                column: "IdUser1",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLaboratories_Roles_IdRole1",
                table: "UserLaboratories",
                column: "IdRole1",
                principalTable: "Roles",
                principalColumn: "IdRole",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLaboratories_Users_IdUser1",
                table: "UserLaboratories",
                column: "IdUser1",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserStudies_UsersData_IdUserData1",
                table: "UserStudies",
                column: "IdUserData1",
                principalTable: "UsersData",
                principalColumn: "IdUserData",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
