using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CienciaArgentina.Microservices.Data.Migrations
{
    public partial class moreEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersData_WorkExperience_WorkExperienceId",
                table: "UsersData");

            migrationBuilder.RenameColumn(
                name: "WorkExperienceId",
                table: "UsersData",
                newName: "NationalityId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersData_WorkExperienceId",
                table: "UsersData",
                newName: "IX_UsersData_NationalityId");

            migrationBuilder.RenameColumn(
                name: "DateCreatedd",
                table: "Laboratories",
                newName: "DateCreated");

            migrationBuilder.AddColumn<int>(
                name: "UserDataId",
                table: "WorkExperience",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentifierType",
                table: "UsersData",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateTable(
                name: "JobOfferCandidates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    ExpectedSalary = table.Column<decimal>(nullable: false),
                    CV = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ReceivedDate = table.Column<DateTime>(nullable: false),
                    IntroductionLetter = table.Column<string>(nullable: true),
                    CandidateNote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfferCandidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobReferrals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobReferrals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PublishDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResearchLines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchLines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobOfferCandidateReferrals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    JobReferralId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfferCandidateReferrals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOfferCandidateReferrals_JobReferrals_JobReferralId",
                        column: x => x.JobReferralId,
                        principalTable: "JobReferrals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobOffer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployerId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Salary = table.Column<decimal>(nullable: false),
                    MinBirthday = table.Column<DateTime>(type: "Date", nullable: false),
                    MaxBirthday = table.Column<DateTime>(type: "Date", nullable: false),
                    AddressId = table.Column<int>(nullable: true),
                    Experience = table.Column<bool>(nullable: false),
                    JobTypeId = table.Column<int>(nullable: true),
                    AcademicRequirements = table.Column<string>(nullable: true),
                    ProjectDescription = table.Column<string>(nullable: true),
                    ResearchTopics = table.Column<string>(nullable: true),
                    ExperimentalModel = table.Column<string>(nullable: true),
                    DurationOffer = table.Column<DateTime>(nullable: false),
                    PresentationLetter = table.Column<bool>(nullable: false),
                    CareerState = table.Column<string>(nullable: true),
                    DateCareerFinish = table.Column<DateTime>(nullable: false),
                    ProjectManager = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOffer_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobOffer_JobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "JobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobOffer_AspNetUsers_UserId",
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

            migrationBuilder.CreateTable(
                name: "UserLanguagesKnowledge",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    UserLanguageId = table.Column<int>(nullable: true),
                    UserDataId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguagesKnowledge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLanguagesKnowledge_UsersData_UserDataId",
                        column: x => x.UserDataId,
                        principalTable: "UsersData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLanguagesKnowledge_UserLanguages_UserLanguageId",
                        column: x => x.UserLanguageId,
                        principalTable: "UserLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobOfferUserLanguajeKnoweldge",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserLanguageKnowledgeId = table.Column<int>(nullable: true),
                    JobOfferId = table.Column<int>(nullable: true),
                    Condition = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOfferUserLanguajeKnoweldge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOfferUserLanguajeKnoweldge_JobOffer_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobOfferUserLanguajeKnoweldge_UserLanguagesKnowledge_UserLanguageKnowledgeId",
                        column: x => x.UserLanguageKnowledgeId,
                        principalTable: "UserLanguagesKnowledge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLanguagesSkill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateDeleted = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserLanguageKnowledgeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguagesSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLanguagesSkill_UserLanguagesKnowledge_UserLanguageKnowledgeId",
                        column: x => x.UserLanguageKnowledgeId,
                        principalTable: "UserLanguagesKnowledge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_UserDataId",
                table: "WorkExperience",
                column: "UserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_AddressId",
                table: "JobOffer",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_JobTypeId",
                table: "JobOffer",
                column: "JobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_UserId",
                table: "JobOffer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfferCandidateReferrals_JobReferralId",
                table: "JobOfferCandidateReferrals",
                column: "JobReferralId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfferDescriptionTags_TagId",
                table: "JobOfferDescriptionTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfferUserLanguajeKnoweldge_JobOfferId",
                table: "JobOfferUserLanguajeKnoweldge",
                column: "JobOfferId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOfferUserLanguajeKnoweldge_UserLanguageKnowledgeId",
                table: "JobOfferUserLanguajeKnoweldge",
                column: "UserLanguageKnowledgeId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryResearchLines_LaboratoryId",
                table: "LaboratoryResearchLines",
                column: "LaboratoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryResearchLines_ResearchLineId",
                table: "LaboratoryResearchLines",
                column: "ResearchLineId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguagesKnowledge_UserDataId",
                table: "UserLanguagesKnowledge",
                column: "UserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguagesKnowledge_UserLanguageId",
                table: "UserLanguagesKnowledge",
                column: "UserLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguagesSkill_UserLanguageKnowledgeId",
                table: "UserLanguagesSkill",
                column: "UserLanguageKnowledgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersData_Countries_NationalityId",
                table: "UsersData",
                column: "NationalityId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperience_UsersData_UserDataId",
                table: "WorkExperience",
                column: "UserDataId",
                principalTable: "UsersData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersData_Countries_NationalityId",
                table: "UsersData");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperience_UsersData_UserDataId",
                table: "WorkExperience");

            migrationBuilder.DropTable(
                name: "JobOfferCandidateReferrals");

            migrationBuilder.DropTable(
                name: "JobOfferCandidates");

            migrationBuilder.DropTable(
                name: "JobOfferDescriptionTags");

            migrationBuilder.DropTable(
                name: "JobOfferUserLanguajeKnoweldge");

            migrationBuilder.DropTable(
                name: "LaboratoryResearchLines");

            migrationBuilder.DropTable(
                name: "UserLanguagesSkill");

            migrationBuilder.DropTable(
                name: "JobReferrals");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "JobOffer");

            migrationBuilder.DropTable(
                name: "ResearchLines");

            migrationBuilder.DropTable(
                name: "UserLanguagesKnowledge");

            migrationBuilder.DropTable(
                name: "JobTypes");

            migrationBuilder.DropTable(
                name: "UserLanguages");

            migrationBuilder.DropIndex(
                name: "IX_WorkExperience_UserDataId",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "UserDataId",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "IdentifierType",
                table: "UsersData");

            migrationBuilder.RenameColumn(
                name: "NationalityId",
                table: "UsersData",
                newName: "WorkExperienceId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersData_NationalityId",
                table: "UsersData",
                newName: "IX_UsersData_WorkExperienceId");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Laboratories",
                newName: "DateCreatedd");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeleted",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersData_WorkExperience_WorkExperienceId",
                table: "UsersData",
                column: "WorkExperienceId",
                principalTable: "WorkExperience",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
