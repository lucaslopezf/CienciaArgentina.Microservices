using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class UserLaboratory
    {
        public int Id { get; set; }
        public Laboratory IdLaboratory { get; set; }
        public Rol IdRol { get; set; }
        public User IdUser { get; set; }
    }
}
