using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CienciaArgentina.Microservices.Data.Migrations
{
    public partial class Sex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "UsersData");

            migrationBuilder.AddColumn<int>(
                name: "IdSex1",
                table: "UsersData",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sex",
                columns: table => new
                {
                    IdSex = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sex", x => x.IdSex);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersData_IdSex1",
                table: "UsersData",
                column: "IdSex1");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersData_Sex_IdSex1",
                table: "UsersData",
                column: "IdSex1",
                principalTable: "Sex",
                principalColumn: "IdSex",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersData_Sex_IdSex1",
                table: "UsersData");

            migrationBuilder.DropTable(
                name: "Sex");

            migrationBuilder.DropIndex(
                name: "IX_UsersData_IdSex1",
                table: "UsersData");

            migrationBuilder.DropColumn(
                name: "IdSex1",
                table: "UsersData");

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "UsersData",
                nullable: false,
                defaultValue: 0);
        }
    }
}
