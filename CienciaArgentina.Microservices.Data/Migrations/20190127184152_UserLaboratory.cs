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
                name: "UserLaboratory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdLaboratoryId = table.Column<int>(nullable: true),
                    IdRolId = table.Column<int>(nullable: true),
                    IdUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLaboratory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLaboratory_Laboratory_IdLaboratoryId",
                        column: x => x.IdLaboratoryId,
                        principalTable: "Laboratory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLaboratory_Rol_IdRolId",
                        column: x => x.IdRolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLaboratory_Users_IdUserId",
                        column: x => x.IdUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLaboratory_IdLaboratoryId",
                table: "UserLaboratory",
                column: "IdLaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLaboratory_IdRolId",
                table: "UserLaboratory",
                column: "IdRolId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLaboratory_IdUserId",
                table: "UserLaboratory",
                column: "IdUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLaboratory");
        }
    }
}
