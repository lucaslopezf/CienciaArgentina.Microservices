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
    [Migration("20190127184259_UserInstitute")]
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ActionKey");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Additionals");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<string>("Department");

                    b.Property<string>("State");

                    b.Property<string>("StreetName");

                    b.Property<string>("StreetNumber");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Iso2");

                    b.Property<string>("Iso3");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Institute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<string>("Description");

                    b.Property<string>("DescriptionLarge");

                    b.Property<string>("Initials");

                    b.Property<string>("Link");

                    b.Property<string>("Logo");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Institute");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Addittions");

                    b.Property<string>("Charge");

                    b.Property<string>("Company");

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Laboratory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Boss");

                    b.Property<string>("Description");

                    b.Property<int?>("IdAddressId");

                    b.Property<int?>("IdInstituteId");

                    b.Property<string>("Link");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("IdAddressId");

                    b.HasIndex("IdInstituteId");

                    b.ToTable("Laboratory");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("RolName");

                    b.HasKey("Id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.SocialNetwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<string>("SocialNetworkName");

                    b.Property<string>("Url");

                    b.Property<Guid?>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SocialNetwork");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdCountryId");

                    b.Property<string>("Name");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("IdCountryId");

                    b.ToTable("University");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Blocked");

                    b.Property<bool>("Confirmed");

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<DateTime>("Birthday");

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<string>("Email");

                    b.Property<string>("Identifier");

                    b.Property<int?>("JobId");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Name");

                    b.Property<string>("Sex");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("JobId");

                    b.ToTable("UserData");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserInstitute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdInstituteId");

                    b.Property<int?>("IdRolId");

                    b.Property<Guid?>("IdUserId");

                    b.HasKey("Id");

                    b.HasIndex("IdInstituteId");

                    b.HasIndex("IdRolId");

                    b.HasIndex("IdUserId");

                    b.ToTable("UserInstitute");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserKeys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<int?>("IdActionKeyId");

                    b.Property<Guid?>("IdUserId");

                    b.Property<bool>("Used");

                    b.HasKey("Id");

                    b.HasIndex("IdActionKeyId");

                    b.HasIndex("IdUserId");

                    b.ToTable("UserKeys");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserLaboratory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdLaboratoryId");

                    b.Property<int?>("IdRolId");

                    b.Property<Guid?>("IdUserId");

                    b.HasKey("Id");

                    b.HasIndex("IdLaboratoryId");

                    b.HasIndex("IdRolId");

                    b.HasIndex("IdUserId");

                    b.ToTable("UserLaboratory");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserStudy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Carrer");

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<int?>("IdTypeId");

                    b.Property<int?>("IdUniversityId");

                    b.Property<int?>("IdUserDataId");

                    b.Property<string>("Institution");

                    b.HasKey("Id");

                    b.HasIndex("IdTypeId");

                    b.HasIndex("IdUniversityId");

                    b.HasIndex("IdUserDataId");

                    b.ToTable("UserStudy");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserStudyTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("UserStudyTypes");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Institute", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.Laboratory", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Address", "IdAddress")
                        .WithMany()
                        .HasForeignKey("IdAddressId");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Institute", "IdInstitute")
                        .WithMany()
                        .HasForeignKey("IdInstituteId");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.SocialNetwork", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.University", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Country", "IdCountry")
                        .WithMany()
                        .HasForeignKey("IdCountryId");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserData", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserInstitute", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Institute", "IdInstitute")
                        .WithMany()
                        .HasForeignKey("IdInstituteId");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Rol", "IdRol")
                        .WithMany()
                        .HasForeignKey("IdRolId");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.User", "IdUser")
                        .WithMany()
                        .HasForeignKey("IdUserId");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserKeys", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.ActionKey", "IdActionKey")
                        .WithMany()
                        .HasForeignKey("IdActionKeyId");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.User", "IdUser")
                        .WithMany()
                        .HasForeignKey("IdUserId");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserLaboratory", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Laboratory", "IdLaboratory")
                        .WithMany()
                        .HasForeignKey("IdLaboratoryId");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.Rol", "IdRol")
                        .WithMany()
                        .HasForeignKey("IdRolId");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.User", "IdUser")
                        .WithMany()
                        .HasForeignKey("IdUserId");
                });

            modelBuilder.Entity("CienciaArgentina.Microservices.Entities.Models.UserStudy", b =>
                {
                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.UserStudyTypes", "IdType")
                        .WithMany()
                        .HasForeignKey("IdTypeId");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.University", "IdUniversity")
                        .WithMany()
                        .HasForeignKey("IdUniversityId");

                    b.HasOne("CienciaArgentina.Microservices.Entities.Models.UserData", "IdUserData")
                        .WithMany()
                        .HasForeignKey("IdUserDataId");
                });
#pragma warning restore 612, 618
        }
    }
}
