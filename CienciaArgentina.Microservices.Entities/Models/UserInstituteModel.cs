using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class UserInstitute
    {
        [Key]
        public int Id { get; set; }
        public Institute Institute { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
