using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CienciaArgentina.Microservices.Data.Migrations
{
    public partial class Laboratory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Laboratories",
                columns: table => new
                {
                    IdLaboratory = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Boss = table.Column<string>(nullable: true),
                    IdAddress1 = table.Column<int>(nullable: true),
                    IdInstitute1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratories", x => x.IdLaboratory);
                    table.ForeignKey(
                        name: "FK_Laboratories_Addresses_IdAddress1",
                        column: x => x.IdAddress1,
                        principalTable: "Addresses",
                        principalColumn: "IdAddress",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Laboratories_Institutes_IdInstitute1",
                        column: x => x.IdInstitute1,
                        principalTable: "Institutes",
                        principalColumn: "IdInstitute",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Laboratories_IdAddress1",
                table: "Laboratories",
                column: "IdAddress1");

            migrationBuilder.CreateIndex(
                name: "IX_Laboratories_IdInstitute1",
                table: "Laboratories",
                column: "IdInstitute1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laboratories");
        }
    }
}
