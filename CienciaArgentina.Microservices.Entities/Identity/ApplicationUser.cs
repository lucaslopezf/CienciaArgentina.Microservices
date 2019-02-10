using System;
using System.Collections.Generic;
using System.Text;
using CienciaArgentina.Microservices.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace CienciaArgentina.Microservices.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime DateDeleted { get; set; }
    }
}
