using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class Sex
    {
        [Key]
        public int IdSex { get; set; }
        public string Description { get; set; }
    }
}
