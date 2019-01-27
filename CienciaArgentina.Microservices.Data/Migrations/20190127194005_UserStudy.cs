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
                name: "UserStudies",
                columns: table => new
                {
                    IdUserStudy = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUserStudyType1 = table.Column<int>(nullable: true),
                    Carrer = table.Column<string>(nullable: true),
                    Institution = table.Column<string>(nullable: true),
                    Additional = table.Column<string>(nullable: true),
                    IdUniversity1 = table.Column<int>(nullable: true),
                    IdUserData1 = table.Column<int>(nullable: true),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStudies", x => x.IdUserStudy);
                    table.ForeignKey(
                        name: "FK_UserStudies_Universities_IdUniversity1",
                        column: x => x.IdUniversity1,
                        principalTable: "Universities",
                        principalColumn: "IdUniversity",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserStudies_UsersData_IdUserData1",
                        column: x => x.IdUserData1,
                        principalTable: "UsersData",
                        principalColumn: "IdUserData",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserStudies_UserStudyTypes_IdUserStudyType1",
                        column: x => x.IdUserStudyType1,
                        principalTable: "UserStudyTypes",
                        principalColumn: "IdUserStudyType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserStudies_IdUniversity1",
                table: "UserStudies",
                column: "IdUniversity1");

            migrationBuilder.CreateIndex(
                name: "IX_UserStudies_IdUserData1",
                table: "UserStudies",
                column: "IdUserData1");

            migrationBuilder.CreateIndex(
                name: "IX_UserStudies_IdUserStudyType1",
                table: "UserStudies",
                column: "IdUserStudyType1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserStudies");
        }
    }
}
