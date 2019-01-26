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
    }
}
