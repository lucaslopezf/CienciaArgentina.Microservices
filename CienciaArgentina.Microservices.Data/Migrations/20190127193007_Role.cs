using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CienciaArgentina.Microservices.Data.Migrations
{
    public partial class Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdRole1",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUserData1",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdRole1",
                table: "Users",
                column: "IdRole1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdUserData1",
                table: "Users",
                column: "IdUserData1");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_IdRole1",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersData_IdUserData1",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdRole1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdUserData1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdRole1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdUserData1",
                table: "Users");
        }
    }
}
