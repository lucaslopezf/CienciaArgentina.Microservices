using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CienciaArgentina.Microservices.Data.Migrations
{
    public partial class UserInstitute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInstitutes",
                columns: table => new
                {
                    IdUserInstitute = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdInstitute1 = table.Column<int>(nullable: true),
                    IdRole1 = table.Column<int>(nullable: true),
                    IdUser1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInstitutes", x => x.IdUserInstitute);
                    table.ForeignKey(
                        name: "FK_UserInstitutes_Institutes_IdInstitute1",
                        column: x => x.IdInstitute1,
                        principalTable: "Institutes",
                        principalColumn: "IdInstitute",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserInstitutes_Roles_IdRole1",
                        column: x => x.IdRole1,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserInstitutes_Users_IdUser1",
                        column: x => x.IdUser1,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInstitutes_IdInstitute1",
                table: "UserInstitutes",
                column: "IdInstitute1");

            migrationBuilder.CreateIndex(
                name: "IX_UserInstitutes_IdRole1",
                table: "UserInstitutes",
                column: "IdRole1");

            migrationBuilder.CreateIndex(
                name: "IX_UserInstitutes_IdUser1",
                table: "UserInstitutes",
                column: "IdUser1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInstitutes");
        }
    }
}
