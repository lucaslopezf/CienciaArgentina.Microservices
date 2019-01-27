using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CienciaArgentina.Microservices.Data.Migrations
{
    public partial class UserStudy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserStudyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStudyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserStudy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdTypeId = table.Column<int>(nullable: true),
                    Carrer = table.Column<string>(nullable: true),
                    Institution = table.Column<string>(nullable: true),
                    IdUniversityId = table.Column<Guid>(nullable: true),
                    IdUserDataId = table.Column<Guid>(nullable: true),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStudy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserStudy_UserStudyTypes_IdTypeId",
                        column: x => x.IdTypeId,
                        principalTable: "UserStudyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserStudy_University_IdUniversityId",
                        column: x => x.IdUniversityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserStudy_UserData_IdUserDataId",
                        column: x => x.IdUserDataId,
                        principalTable: "UserData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserStudy_IdTypeId",
                table: "UserStudy",
                column: "IdTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStudy_IdUniversityId",
                table: "UserStudy",
                column: "IdUniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStudy_IdUserDataId",
                table: "UserStudy",
                column: "IdUserDataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserStudy");

            migrationBuilder.DropTable(
                name: "UserStudyTypes");
        }
    }
}
