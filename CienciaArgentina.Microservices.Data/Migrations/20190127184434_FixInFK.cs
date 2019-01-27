using Microsoft.EntityFrameworkCore.Migrations;

namespace CienciaArgentina.Microservices.Data.Migrations
{
    public partial class FixInFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institute_Address_AddressId",
                table: "Institute");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialNetwork_Users_UserId",
                table: "SocialNetwork");

            migrationBuilder.DropForeignKey(
                name: "FK_UserData_Address_AddressId",
                table: "UserData");

            migrationBuilder.DropForeignKey(
                name: "FK_UserData_Job_JobId",
                table: "UserData");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "UserData",
                newName: "IdJobId");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "UserData",
                newName: "IdAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_UserData_JobId",
                table: "UserData",
                newName: "IX_UserData_IdJobId");

            migrationBuilder.RenameIndex(
                name: "IX_UserData_AddressId",
                table: "UserData",
                newName: "IX_UserData_IdAddressId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SocialNetwork",
                newName: "IdUserId");

            migrationBuilder.RenameIndex(
                name: "IX_SocialNetwork_UserId",
                table: "SocialNetwork",
                newName: "IX_SocialNetwork_IdUserId");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Institute",
                newName: "IdAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Institute_AddressId",
                table: "Institute",
                newName: "IX_Institute_IdAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Institute_Address_IdAddressId",
                table: "Institute",
                column: "IdAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialNetwork_Users_IdUserId",
                table: "SocialNetwork",
                column: "IdUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_Address_IdAddressId",
                table: "UserData",
                column: "IdAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_Job_IdJobId",
                table: "UserData",
                column: "IdJobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institute_Address_IdAddressId",
                table: "Institute");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialNetwork_Users_IdUserId",
                table: "SocialNetwork");

            migrationBuilder.DropForeignKey(
                name: "FK_UserData_Address_IdAddressId",
                table: "UserData");

            migrationBuilder.DropForeignKey(
                name: "FK_UserData_Job_IdJobId",
                table: "UserData");

            migrationBuilder.RenameColumn(
                name: "IdJobId",
                table: "UserData",
                newName: "JobId");

            migrationBuilder.RenameColumn(
                name: "IdAddressId",
                table: "UserData",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_UserData_IdJobId",
                table: "UserData",
                newName: "IX_UserData_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_UserData_IdAddressId",
                table: "UserData",
                newName: "IX_UserData_AddressId");

            migrationBuilder.RenameColumn(
                name: "IdUserId",
                table: "SocialNetwork",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SocialNetwork_IdUserId",
                table: "SocialNetwork",
                newName: "IX_SocialNetwork_UserId");

            migrationBuilder.RenameColumn(
                name: "IdAddressId",
                table: "Institute",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Institute_IdAddressId",
                table: "Institute",
                newName: "IX_Institute_AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Institute_Address_AddressId",
                table: "Institute",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialNetwork_Users_UserId",
                table: "SocialNetwork",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_Address_AddressId",
                table: "UserData",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_Job_JobId",
                table: "UserData",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
