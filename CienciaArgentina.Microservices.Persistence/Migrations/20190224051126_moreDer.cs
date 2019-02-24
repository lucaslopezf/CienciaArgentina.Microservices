using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CienciaArgentina.Microservices.Data.Migrations
{
    public partial class moreDer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersData_SocialNetworks_SocialNetworkId",
                table: "UsersData");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersData_UserInstitutes_UserInstituteId",
                table: "UsersData");

            migrationBuilder.DropTable(
                name: "LaboratoryResearchLines");

            migrationBuilder.DropTable(
                name: "UserInstitutes");

            migrationBuilder.DropTable(
                name: "UserLaboratories");

            migrationBuilder.DropTable(
                name: "ResearchLines");

            migrationBuilder.DropTable(
                name: "Laboratories");

            migrationBuilder.DropTable(
                name: "Institutes");

            migrationBuilder.DropIndex(
                name: "IX_UsersData_SocialNetworkId",
                table: "UsersData");

            migrationBuilder.DropColumn(
                name: "SocialNetworkId",
                table: "UsersData");

            migrationBuilder.RenameColumn(
                name: "UserInstituteId",
                table: "UsersData",
                newName: "UserOrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersData_UserInstituteId",
                table: "UsersData",
                newName: "IX_UsersData_UserOrganizationId");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "SocialNetworks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "SocialNetworks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserDataId",
                table: "SocialNetworks",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrganizationProjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    About = table.Column<string>(nullable: true),
                    ResponsableId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationProjects_UsersData_ResponsableId",
                        column: x => x.ResponsableId,
                        principalTable: "UsersData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PayPlatform = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telephones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    CountryCode = table.Column<int>(nullable: false),
                    AreaCode = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false),
                    UserDataId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telephones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telephones_UsersData_UserDataId",
                        column: x => x.UserDataId,
                        principalTable: "UsersData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    OrganizationTypeId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Initials = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DescriptionLarge = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Organizations_OrganizationTypes_OrganizationTypeId",
                        column: x => x.OrganizationTypeId,
                        principalTable: "OrganizationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserOrganizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: true),
                    PositionId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOrganizations_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserOrganizations_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserOrganizations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentProjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true),
                    OrganizationProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentProjects_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentProjects_OrganizationProjects_OrganizationProjectId",
                        column: x => x.OrganizationProjectId,
                        principalTable: "OrganizationProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaperDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DeparmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaperDepartment_Departments_DeparmentId",
                        column: x => x.DeparmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true),
                    PositionId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDepartments_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDepartments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Papers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Magazine = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    PaperDepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Papers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Papers_PaperDepartment_PaperDepartmentId",
                        column: x => x.PaperDepartmentId,
                        principalTable: "PaperDepartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetworks_DepartmentId",
                table: "SocialNetworks",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetworks_OrganizationId",
                table: "SocialNetworks",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialNetworks_UserDataId",
                table: "SocialNetworks",
                column: "UserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentProjects_DepartmentId",
                table: "DepartmentProjects",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentProjects_OrganizationProjectId",
                table: "DepartmentProjects",
                column: "OrganizationProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_AddressId",
                table: "Departments",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_OrganizationId",
                table: "Departments",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationProjects_ResponsableId",
                table: "OrganizationProjects",
                column: "ResponsableId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_AddressId",
                table: "Organizations",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OrganizationTypeId",
                table: "Organizations",
                column: "OrganizationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaperDepartment_DeparmentId",
                table: "PaperDepartment",
                column: "DeparmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Papers_PaperDepartmentId",
                table: "Papers",
                column: "PaperDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Telephones_UserDataId",
                table: "Telephones",
                column: "UserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDepartments_DepartmentId",
                table: "UserDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDepartments_PositionId",
                table: "UserDepartments",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDepartments_UserId",
                table: "UserDepartments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizations_OrganizationId",
                table: "UserOrganizations",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizations_PositionId",
                table: "UserOrganizations",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrganizations_UserId",
                table: "UserOrganizations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialNetworks_Departments_DepartmentId",
                table: "SocialNetworks",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialNetworks_Organizations_OrganizationId",
                table: "SocialNetworks",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialNetworks_UsersData_UserDataId",
                table: "SocialNetworks",
                column: "UserDataId",
                principalTable: "UsersData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersData_UserOrganizations_UserOrganizationId",
                table: "UsersData",
                column: "UserOrganizationId",
                principalTable: "UserOrganizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialNetworks_Departments_DepartmentId",
                table: "SocialNetworks");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialNetworks_Organizations_OrganizationId",
                table: "SocialNetworks");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialNetworks_UsersData_UserDataId",
                table: "SocialNetworks");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersData_UserOrganizations_UserOrganizationId",
                table: "UsersData");

            migrationBuilder.DropTable(
                name: "DepartmentProjects");

            migrationBuilder.DropTable(
                name: "Papers");

            migrationBuilder.DropTable(
                name: "Telephones");

            migrationBuilder.DropTable(
                name: "UserDepartments");

            migrationBuilder.DropTable(
                name: "UserOrganizations");

            migrationBuilder.DropTable(
                name: "OrganizationProjects");

            migrationBuilder.DropTable(
                name: "PaperDepartment");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "OrganizationTypes");

            migrationBuilder.DropIndex(
                name: "IX_SocialNetworks_DepartmentId",
                table: "SocialNetworks");

            migrationBuilder.DropIndex(
                name: "IX_SocialNetworks_OrganizationId",
                table: "SocialNetworks");

            migrationBuilder.DropIndex(
                name: "IX_SocialNetworks_UserDataId",
                table: "SocialNetworks");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "SocialNetworks");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "SocialNetworks");

            migrationBuilder.DropColumn(
                name: "UserDataId",
                table: "SocialNetworks");

            migrationBuilder.RenameColumn(
                name: "UserOrganizationId",
                table: "UsersData",
                newName: "UserInstituteId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersData_UserOrganizationId",
                table: "UsersData",
                newName: "IX_UsersData_UserInstituteId");

            migrationBuilder.AddColumn<int>(
                name: "SocialNetworkId",
                table: "UsersData",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Institutes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DescriptionLarge = table.Column<string>(nullable: true),
                    Initials = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Institutes_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResearchLines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchLines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laboratories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    InstituteId = table.Column<int>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laboratories_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Laboratories_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserInstitutes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    InstituteId = table.Column<int>(nullable: true),
                    PositionId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInstitutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInstitutes_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserInstitutes_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserInstitutes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryResearchLines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    LaboratoryId = table.Column<int>(nullable: true),
                    ResearchLineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryResearchLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaboratoryResearchLines_Laboratories_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalTable: "Laboratories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LaboratoryResearchLines_ResearchLines_ResearchLineId",
                        column: x => x.ResearchLineId,
                        principalTable: "ResearchLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLaboratories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    LaboratoryId = table.Column<int>(nullable: true),
                    PositionId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLaboratories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLaboratories_Laboratories_LaboratoryId",
                        column: x => x.LaboratoryId,
                        principalTable: "Laboratories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLaboratories_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLaboratories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersData_SocialNetworkId",
                table: "UsersData",
                column: "SocialNetworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutes_AddressId",
                table: "Institutes",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Laboratories_AddressId",
                table: "Laboratories",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Laboratories_InstituteId",
                table: "Laboratories",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryResearchLines_LaboratoryId",
                table: "LaboratoryResearchLines",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryResearchLines_ResearchLineId",
                table: "LaboratoryResearchLines",
                column: "ResearchLineId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInstitutes_InstituteId",
                table: "UserInstitutes",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInstitutes_PositionId",
                table: "UserInstitutes",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInstitutes_UserId",
                table: "UserInstitutes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLaboratories_LaboratoryId",
                table: "UserLaboratories",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLaboratories_PositionId",
                table: "UserLaboratories",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLaboratories_UserId",
                table: "UserLaboratories",
                column: "UserId");

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
        }
    }
}
