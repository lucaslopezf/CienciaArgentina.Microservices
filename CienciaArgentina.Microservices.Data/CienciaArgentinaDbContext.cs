﻿using System;
using System.Collections.Generic;
using System.Text;
using CienciaArgentina.Microservices.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CienciaArgentina.Microservices.Data
{
    public class CienciaArgentinaDbContext : DbContext
    {
        public CienciaArgentinaDbContext(DbContextOptions<CienciaArgentinaDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<UserData> UsersData { get; set; }
        public DbSet<Sex> Sex { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<UserStudyType> UserStudyTypes { get; set; }
        public DbSet<UserStudy> UserStudies { get; set; }
        public DbSet<Laboratory> Laboratories { get; set; }
        public DbSet<ActionKey> ActionKeys { get; set; }
        public DbSet<UserKey> UserKeys { get; set; }
        public DbSet<UserLaboratory> UserLaboratories { get; set; }
        public DbSet<UserInstitute> UserInstitutes { get; set; }
        
    }
}
