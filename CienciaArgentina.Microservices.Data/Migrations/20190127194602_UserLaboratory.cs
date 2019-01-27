using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CienciaArgentina.Microservices.Data.Migrations
{
    public partial class UserLaboratory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLaboratories",
                columns: table => new
                {
                    IdUserLaboratory = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdLaboratory1 = table.Column<int>(nullable: true),
                    IdRole1 = table.Column<int>(nullable: true),
                    IdUser1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLaboratories", x => x.IdUserLaboratory);
                    table.ForeignKey(
                        name: "FK_UserLaboratories_Laboratories_IdLaboratory1",
                        column: x => x.IdLaboratory1,
                        principalTable: "Laboratories",
                        principalColumn: "IdLaboratory",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLaboratories_Roles_IdRole1",
                        column: x => x.IdRole1,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLaboratories_Users_IdUser1",
                        column: x => x.IdUser1,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLaboratories_IdLaboratory1",
                table: "UserLaboratories",
                column: "IdLaboratory1");

            migrationBuilder.CreateIndex(
                name: "IX_UserLaboratories_IdRole1",
                table: "UserLaboratories",
                column: "IdRole1");

            migrationBuilder.CreateIndex(
                name: "IX_UserLaboratories_IdUser1",
                table: "UserLaboratories",
                column: "IdUser1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLaboratories");
        }
    }
}
