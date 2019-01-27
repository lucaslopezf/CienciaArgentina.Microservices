using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class UserStudyType
    {
        [Key]
        public int IdUserStudyType { get; set; }
        public string Description { get; set; }
    }
}
