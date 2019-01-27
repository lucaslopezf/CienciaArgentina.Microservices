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
                name: "UserInstitute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdInstituteId = table.Column<int>(nullable: true),
                    IdRolId = table.Column<int>(nullable: true),
                    IdUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInstitute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInstitute_Institute_IdInstituteId",
                        column: x => x.IdInstituteId,
                        principalTable: "Institute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserInstitute_Rol_IdRolId",
                        column: x => x.IdRolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserInstitute_Users_IdUserId",
                        column: x => x.IdUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserInstitute_IdInstituteId",
                table: "UserInstitute",
                column: "IdInstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInstitute_IdRolId",
                table: "UserInstitute",
                column: "IdRolId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInstitute_IdUserId",
                table: "UserInstitute",
                column: "IdUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInstitute");
        }
    }
}
