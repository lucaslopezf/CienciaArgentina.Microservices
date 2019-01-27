using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class UserLaboratory
    {
        [Key]
        public int IdUserLaboratory { get; set; }
        public Laboratory IdLaboratory { get; set; }
        public Role IdRole { get; set; }
        public User IdUser { get; set; }
    }
}
