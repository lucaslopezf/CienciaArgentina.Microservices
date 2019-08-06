using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CienciaArgentina.Microservices.Persistence.Migrations
{
    public partial class editJobOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffer_Addresses_AddressId",
                table: "JobOffer");

            migrationBuilder.DropTable(
                name: "JobOfferDescriptionTags");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrganizationProjects");

            migrationBuilder.DropColumn(
                name: "EmployerId",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "MaxBirthday",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "MinBirthday",
                table: "JobOffer");

            migrationBuilder.RenameColumn(
                name: "ProjectDescription",
                table: "JobOffer",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "JobOffer",
                newName: "OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_JobOffer_AddressId",
                table: "JobOffer",
                newName: "IX_JobOffer_OrganizationId");

            migrationBuilder.AddColumn<int>(
                name: "JobOfferId",
                table: "Tags",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Acronyms",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "JobOffer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "JobOffer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Addresses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_JobOfferId",
                table: "Tags",
                column: "JobOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffer_Organizations_OrganizationId",
                table: "JobOffer",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_JobOffer_JobOfferId",
                table: "Tags",
                column: "JobOfferId",
                principalTable: "JobOffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffer_Organizations_OrganizationId",
                table: "JobOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_JobOffer_JobOfferId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_JobOfferId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "JobOfferId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Acronyms",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "JobOffer",
                newName: "ProjectDescription");

            migrationBuilder.RenameColumn(
                name: "OrganizationId",
                table: "JobOffer",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_JobOffer_OrganizationId",
                table: "JobOffer",
                newName: "IX_JobOffer_AddressId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrganizationProjects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployerId",
                table: "JobOffer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "MaxBirthday",
                table: "JobOffer",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "MinBirthday",
                table: "JobOffer",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "JobOfferDescriptionTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    TagId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfferDescriptionTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOfferDescriptionTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobOfferDescriptionTags_TagId",
                table: "JobOfferDescriptionTags",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffer_Addresses_AddressId",
                table: "JobOffer",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
