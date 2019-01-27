using System;
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
        public DbSet<Address> Address { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<UserData> UserData { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Institute> Institute { get; set; }
        public DbSet<SocialNetwork> SocialNetwork { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<University> University { get; set; }
        public DbSet<Laboratory> Laboratory { get; set; }
        public DbSet<ActionKey> ActionKey { get; set; }
    }
}
