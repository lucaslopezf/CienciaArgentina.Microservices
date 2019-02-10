﻿// <auto-generated />
using System;
using CienciaArgentina.Microservices.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CienciaArgentina.Microservices.Data.Migrations
{
    [DbContext(typeof(CienciaArgentinaDbContext))]
    [Migration("20190210052550_NulleableDeleteDates")]
    partial class NulleableDeleteDates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DateDeleted");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Additionals");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<string>("Department");

                    b.Property<int?>("LocalityId");

                    b.Property<string>("StreetName");

                    b.Property<string>("StreetNumber");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("LocalityId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<string>("Description");

                    b.Property<int?>("StateId");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<string>("Iso2");

                    b.Property<string>("Iso3");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Institute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<string>("Description");

                    b.Property<string>("DescriptionLarge");

                    b.Property<string>("Initials");

                    b.Property<string>("Link");

                    b.Property<string>("Logo");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Institutes");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Laboratory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<DateTime>("DateCreatedd");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<string>("Description");

                    b.Property<int?>("InstituteId");

                    b.Property<string>("Link");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("InstituteId");

                    b.ToTable("Laboratories");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Locality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Localities");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<string>("Description");

                    b.Property<string>("PositionName");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Sex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Sex");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.SocialNetwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<string>("SocialNetworkName");

                    b.Property<string>("Url");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("SocialNetworks");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<string>("Identifier");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Name");

                    b.Property<int?>("SexId");

                    b.Property<int?>("SocialNetworkId");

                    b.Property<Guid>("UserId");

                    b.Property<int?>("UserInstituteId");

                    b.Property<int?>("WorkExperienceId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("SexId");

                    b.HasIndex("SocialNetworkId");

                    b.HasIndex("UserInstituteId");

                    b.HasIndex("WorkExperienceId");

                    b.ToTable("UsersData");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserInstitute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<int?>("InstituteId");

                    b.Property<int?>("PositionId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.HasIndex("PositionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserInstitutes");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserLaboratory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<int?>("LaboratoryId");

                    b.Property<int?>("PositionId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("LaboratoryId");

                    b.HasIndex("PositionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserLaboratories");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserStudy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Additional");

                    b.Property<int?>("ApprovedSubjects");

                    b.Property<string>("Carrer");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<string>("Institution");

                    b.Property<int?>("TotalSubjects");

                    b.Property<int?>("UniversityId");

                    b.Property<int?>("UserDataId");

                    b.Property<int?>("UserStudyCompletionId");

                    b.Property<int?>("UserStudyTypeId");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.HasIndex("UserDataId");

                    b.HasIndex("UserStudyCompletionId");

                    b.HasIndex("UserStudyTypeId");

                    b.ToTable("UserStudies");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserStudyCompletion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("UserStudiesCompletion");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserStudyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("UserStudyTypes");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.WorkExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Addittions");

                    b.Property<int?>("AddressId");

                    b.Property<string>("Charge");

                    b.Property<string>("Company");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateDeleted");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("WorkExperience");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Address", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Locality", "Locality")
                        .WithMany()
                        .HasForeignKey("LocalityId");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.City", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Institute", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Laboratory", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Institute", "Institute")
                        .WithMany()
                        .HasForeignKey("InstituteId");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Locality", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.State", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.University", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserData", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Sex", "Sex")
                        .WithMany()
                        .HasForeignKey("SexId");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.SocialNetwork", "SocialNetwork")
                        .WithMany()
                        .HasForeignKey("SocialNetworkId");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.UserInstitute", "UserInstitute")
                        .WithMany()
                        .HasForeignKey("UserInstituteId");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.WorkExperience", "WorkExperience")
                        .WithMany()
                        .HasForeignKey("WorkExperienceId");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserInstitute", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Institute", "Institute")
                        .WithMany()
                        .HasForeignKey("InstituteId");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Identity.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserLaboratory", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Laboratory", "Laboratory")
                        .WithMany()
                        .HasForeignKey("LaboratoryId");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Identity.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserStudy", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.University", "University")
                        .WithMany()
                        .HasForeignKey("UniversityId");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.UserData", "UserData")
                        .WithMany()
                        .HasForeignKey("UserDataId");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.UserStudyCompletion", "UserStudyCompletion")
                        .WithMany()
                        .HasForeignKey("UserStudyCompletionId");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.UserStudyType", "UserStudyType")
                        .WithMany()
                        .HasForeignKey("UserStudyTypeId");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.WorkExperience", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CienciaArgentina.Microservices.Entities.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
