using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class Rol
    {
        public Guid Id { get; set; }
        public string RolName { get; set; }
        public string Description { get; set; }
    }
}
