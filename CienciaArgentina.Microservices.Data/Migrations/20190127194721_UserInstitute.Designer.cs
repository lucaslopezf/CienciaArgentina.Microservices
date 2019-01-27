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
    [Migration("20190127194721_UserInstitute")]
    partial class UserInstitute
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.ActionKey", b =>
                {
                    b.Property<int>("IdActionKey")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("IdActionKey");

                    b.ToTable("ActionKeys");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Address", b =>
                {
                    b.Property<int>("IdAddress")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Additionals");

                    b.Property<string>("Country");

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<string>("Department");

                    b.Property<string>("State");

                    b.Property<string>("StreetName");

                    b.Property<string>("StreetNumber");

                    b.Property<string>("ZipCode");

                    b.HasKey("IdAddress");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Country", b =>
                {
                    b.Property<int>("IdCountry")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Iso2");

                    b.Property<string>("Iso3");

                    b.Property<string>("Name");

                    b.HasKey("IdCountry");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Institute", b =>
                {
                    b.Property<int>("IdInstitute")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<string>("Description");

                    b.Property<string>("DescriptionLarge");

                    b.Property<int?>("IdAddress1");

                    b.Property<string>("Initials");

                    b.Property<string>("Link");

                    b.Property<string>("Logo");

                    b.Property<string>("Name");

                    b.HasKey("IdInstitute");

                    b.HasIndex("IdAddress1");

                    b.ToTable("Institutes");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Job", b =>
                {
                    b.Property<int>("IdJob")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Addittions");

                    b.Property<string>("Charge");

                    b.Property<string>("Company");

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<string>("Description");

                    b.HasKey("IdJob");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Laboratory", b =>
                {
                    b.Property<int>("IdLaboratory")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Boss");

                    b.Property<string>("Description");

                    b.Property<int?>("IdAddress1");

                    b.Property<int?>("IdInstitute1");

                    b.Property<string>("Link");

                    b.Property<string>("Name");

                    b.HasKey("IdLaboratory");

                    b.HasIndex("IdAddress1");

                    b.HasIndex("IdInstitute1");

                    b.ToTable("Laboratories");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Role", b =>
                {
                    b.Property<int>("IdRole")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("RoleName");

                    b.HasKey("IdRole");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Sex", b =>
                {
                    b.Property<int>("IdSex")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("IdSex");

                    b.ToTable("Sex");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.SocialNetwork", b =>
                {
                    b.Property<int>("IdSocialNetwork")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<Guid?>("IdUser1");

                    b.Property<string>("SocialNetworkName");

                    b.Property<string>("Url");

                    b.Property<string>("UserName");

                    b.HasKey("IdSocialNetwork");

                    b.HasIndex("IdUser1");

                    b.ToTable("SocialNetworks");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.University", b =>
                {
                    b.Property<int>("IdUniversity")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdCountry1");

                    b.Property<string>("Name");

                    b.Property<int>("Url");

                    b.HasKey("IdUniversity");

                    b.HasIndex("IdCountry1");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.User", b =>
                {
                    b.Property<Guid>("IdUser")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Blocked");

                    b.Property<bool>("Confirmed");

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<int?>("IdRole1");

                    b.Property<int?>("IdUserData1");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("IdUser");

                    b.HasIndex("IdRole1");

                    b.HasIndex("IdUserData1");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserData", b =>
                {
                    b.Property<int>("IdUserData")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthday");

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<string>("Email");

                    b.Property<int?>("IdAddress1");

                    b.Property<int?>("IdJob1");

                    b.Property<int?>("IdSex1");

                    b.Property<string>("Identifier");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Name");

                    b.HasKey("IdUserData");

                    b.HasIndex("IdAddress1");

                    b.HasIndex("IdJob1");

                    b.HasIndex("IdSex1");

                    b.ToTable("UsersData");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserInstitute", b =>
                {
                    b.Property<int>("IdUserInstitute")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdInstitute1");

                    b.Property<int?>("IdRole1");

                    b.Property<Guid?>("IdUser1");

                    b.HasKey("IdUserInstitute");

                    b.HasIndex("IdInstitute1");

                    b.HasIndex("IdRole1");

                    b.HasIndex("IdUser1");

                    b.ToTable("UserInstitutes");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserKey", b =>
                {
                    b.Property<int>("IdUserKeys")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<int?>("IdActionKey1");

                    b.Property<Guid?>("IdUser1");

                    b.Property<bool>("Used");

                    b.HasKey("IdUserKeys");

                    b.HasIndex("IdActionKey1");

                    b.HasIndex("IdUser1");

                    b.ToTable("UserKeys");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserLaboratory", b =>
                {
                    b.Property<int>("IdUserLaboratory")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdLaboratory1");

                    b.Property<int?>("IdRole1");

                    b.Property<Guid?>("IdUser1");

                    b.HasKey("IdUserLaboratory");

                    b.HasIndex("IdLaboratory1");

                    b.HasIndex("IdRole1");

                    b.HasIndex("IdUser1");

                    b.ToTable("UserLaboratories");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserStudy", b =>
                {
                    b.Property<int>("IdUserStudy")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Additional");

                    b.Property<string>("Carrer");

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<int?>("IdUniversity1");

                    b.Property<int?>("IdUserData1");

                    b.Property<int?>("IdUserStudyType1");

                    b.Property<string>("Institution");

                    b.HasKey("IdUserStudy");

                    b.HasIndex("IdUniversity1");

                    b.HasIndex("IdUserData1");

                    b.HasIndex("IdUserStudyType1");

                    b.ToTable("UserStudies");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserStudyType", b =>
                {
                    b.Property<int>("IdUserStudyType")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("IdUserStudyType");

                    b.ToTable("UserStudyTypes");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Institute", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Address", "IdAddress")
                        .WithMany()
                        .HasForeignKey("IdAddress1");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Laboratory", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Address", "IdAddress")
                        .WithMany()
                        .HasForeignKey("IdAddress1");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Institute", "IdInstitute")
                        .WithMany()
                        .HasForeignKey("IdInstitute1");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.SocialNetwork", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.User", "IdUser")
                        .WithMany()
                        .HasForeignKey("IdUser1");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.University", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Country", "IdCountry")
                        .WithMany()
                        .HasForeignKey("IdCountry1");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.User", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Role", "IdRole")
                        .WithMany()
                        .HasForeignKey("IdRole1");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.UserData", "IdUserData")
                        .WithMany()
                        .HasForeignKey("IdUserData1");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserData", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Address", "IdAddress")
                        .WithMany()
                        .HasForeignKey("IdAddress1");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Job", "IdJob")
                        .WithMany()
                        .HasForeignKey("IdJob1");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Sex", "IdSex")
                        .WithMany()
                        .HasForeignKey("IdSex1");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserInstitute", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Institute", "IdInstitute")
                        .WithMany()
                        .HasForeignKey("IdInstitute1");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Role", "IdRole")
                        .WithMany()
                        .HasForeignKey("IdRole1");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.User", "IdUser")
                        .WithMany()
                        .HasForeignKey("IdUser1");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserKey", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.ActionKey", "IdActionKey")
                        .WithMany()
                        .HasForeignKey("IdActionKey1");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.User", "IdUser")
                        .WithMany()
                        .HasForeignKey("IdUser1");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserLaboratory", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Laboratory", "IdLaboratory")
                        .WithMany()
                        .HasForeignKey("IdLaboratory1");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Role", "IdRole")
                        .WithMany()
                        .HasForeignKey("IdRole1");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.User", "IdUser")
                        .WithMany()
                        .HasForeignKey("IdUser1");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserStudy", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.University", "IdUniversity")
                        .WithMany()
                        .HasForeignKey("IdUniversity1");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.UserData", "IdUserData")
                        .WithMany()
                        .HasForeignKey("IdUserData1");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.UserStudyType", "IdUserStudyType")
                        .WithMany()
                        .HasForeignKey("IdUserStudyType1");
                });
#pragma warning restore 612, 618
        }
    }
}
