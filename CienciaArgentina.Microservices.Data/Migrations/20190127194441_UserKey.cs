using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CienciaArgentina.Microservices.Data.Migrations
{
    public partial class UserKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserKeys",
                columns: table => new
                {
                    IdUserKeys = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUser1 = table.Column<Guid>(nullable: true),
                    IdActionKey1 = table.Column<int>(nullable: true),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    Used = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserKeys", x => x.IdUserKeys);
                    table.ForeignKey(
                        name: "FK_UserKeys_ActionKeys_IdActionKey1",
                        column: x => x.IdActionKey1,
                        principalTable: "ActionKeys",
                        principalColumn: "IdActionKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserKeys_Users_IdUser1",
                        column: x => x.IdUser1,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserKeys_IdActionKey1",
                table: "UserKeys",
                column: "IdActionKey1");

            migrationBuilder.CreateIndex(
                name: "IX_UserKeys_IdUser1",
                table: "UserKeys",
                column: "IdUser1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserKeys");
        }
    }
}
