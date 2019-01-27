using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class UserInstitute
    {
        public int Id { get; set; }
        public Institute IdInstitute { get; set; }
        public Rol IdRol { get; set; }
        public User IdUser { get; set; }
    }
}
