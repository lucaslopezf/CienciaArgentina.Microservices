using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class UserInstitute
    {
        [Key]
        public int IdUserInstitute { get; set; }
        public Institute IdInstitute { get; set; }
        public Role IdRole { get; set; }
        public User IdUser { get; set; }
    }
}
