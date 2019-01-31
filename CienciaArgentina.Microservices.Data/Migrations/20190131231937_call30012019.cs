using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CienciaArgentina.Microservices.Data.Migrations
{
    public partial class call30012019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_States_StateId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInstitutes_Roles_RoleId",
                table: "UserInstitutes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLaboratories_Roles_RoleId",
                table: "UserLaboratories");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersData_Jobs_JobId",
                table: "UsersData");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserKeys");

            migrationBuilder.DropTable(
                name: "ActionKeys");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StateId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "UsersData");

            migrationBuilder.DropColumn(
                name: "Boss",
                table: "Laboratories");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "UsersData",
                newName: "UserInstituteId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersData_JobId",
                table: "UsersData",
                newName: "IX_UsersData_UserInstituteId");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "UserLaboratories",
                newName: "PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLaboratories_RoleId",
                table: "UserLaboratories",
                newName: "IX_UserLaboratories_PositionId");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "UserInstitutes",
                newName: "PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_UserInstitutes_RoleId",
                table: "UserInstitutes",
                newName: "IX_UserInstitutes_PositionId");

            migrationBuilder.AddColumn<int>(
                name: "ApprovedSubjects",
                table: "UserStudies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserStudyCompletionId",
                table: "UserStudies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CareerId",
                table: "UsersData",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SocialNetworkId",
                table: "UsersData",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "States",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Cities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Careers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Company = table.Column<string>(nullable: true),
                    Charge = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Addittions = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Careers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Careers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Localities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localities_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PositionName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserStudiesCompletion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStudiesCompletion", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserStudies_UserStudyCompletionId",
                table: "UserStudies",
                column: "UserStudyCompletionId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersData_CareerId",
                table: "UsersData",
                column: "CareerId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersData_SocialNetworkId",
                table: "UsersData",
                column: "SocialNetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Careers_AddressId",
                table: "Careers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Localities_CityId",
                table: "Localities",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInstitutes_Positions_PositionId",
                table: "UserInstitutes",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLaboratories_Positions_PositionId",
                table: "UserLaboratories",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersData_Careers_CareerId",
                table: "UsersData",
                column: "CareerId",
                principalTable: "Careers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersData_SocialNetworks_SocialNetworkId",
                table: "UsersData",
                column: "SocialNetworkId",
                principalTable: "SocialNetworks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersData_UserInstitutes_UserInstituteId",
                table: "UsersData",
                column: "UserInstituteId",
                principalTable: "UserInstitutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStudies_UserStudiesCompletion_UserStudyCompletionId",
                table: "UserStudies",
                column: "UserStudyCompletionId",
                principalTable: "UserStudiesCompletion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_CountryId",
                table: "States");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInstitutes_Positions_PositionId",
                table: "UserInstitutes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLaboratories_Positions_PositionId",
                table: "UserLaboratories");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersData_Careers_CareerId",
                table: "UsersData");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersData_SocialNetworks_SocialNetworkId",
                table: "UsersData");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersData_UserInstitutes_UserInstituteId",
                table: "UsersData");

            migrationBuilder.DropForeignKey(
                name: "FK_UserStudies_UserStudiesCompletion_UserStudyCompletionId",
                table: "UserStudies");

            migrationBuilder.DropTable(
                name: "Careers");

            migrationBuilder.DropTable(
                name: "Localities");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "UserStudiesCompletion");

            migrationBuilder.DropIndex(
                name: "IX_UserStudies_UserStudyCompletionId",
                table: "UserStudies");

            migrationBuilder.DropIndex(
                name: "IX_UsersData_CareerId",
                table: "UsersData");

            migrationBuilder.DropIndex(
                name: "IX_UsersData_SocialNetworkId",
                table: "UsersData");

            migrationBuilder.DropIndex(
                name: "IX_States_CountryId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Cities_StateId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "ApprovedSubjects",
                table: "UserStudies");

            migrationBuilder.DropColumn(
                name: "UserStudyCompletionId",
                table: "UserStudies");

            migrationBuilder.DropColumn(
                name: "CareerId",
                table: "UsersData");

            migrationBuilder.DropColumn(
                name: "SocialNetworkId",
                table: "UsersData");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "States");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "UserInstituteId",
                table: "UsersData",
                newName: "JobId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersData_UserInstituteId",
                table: "UsersData",
                newName: "IX_UsersData_JobId");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "UserLaboratories",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLaboratories_PositionId",
                table: "UserLaboratories",
                newName: "IX_UserLaboratories_RoleId");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "UserInstitutes",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserInstitutes_PositionId",
                table: "UserInstitutes",
                newName: "IX_UserInstitutes_RoleId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "UsersData",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Boss",
                table: "Laboratories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Addresses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActionKeys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Addittions = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    Charge = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserKeys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActionKeyId = table.Column<int>(nullable: true),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    Used = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserKeys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserKeys_ActionKeys_ActionKeyId",
                        column: x => x.ActionKeyId,
                        principalTable: "ActionKeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserKeys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StateId",
                table: "Addresses",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_AddressId",
                table: "Jobs",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_UserKeys_ActionKeyId",
                table: "UserKeys",
                column: "ActionKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserKeys_UserId",
                table: "UserKeys",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_States_StateId",
                table: "Addresses",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInstitutes_Roles_RoleId",
                table: "UserInstitutes",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLaboratories_Roles_RoleId",
                table: "UserLaboratories",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersData_Jobs_JobId",
                table: "UsersData",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
