using Microsoft.EntityFrameworkCore.Migrations;

namespace CienciaArgentina.Microservices.Persistence.Migrations
{
    public partial class jobOfferEdt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_JobOffer_JobOfferId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_JobOfferId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "JobOfferId",
                table: "Tags");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobOfferId",
                table: "Tags",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_JobOfferId",
                table: "Tags",
                column: "JobOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_JobOffer_JobOfferId",
                table: "Tags",
                column: "JobOfferId",
                principalTable: "JobOffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
