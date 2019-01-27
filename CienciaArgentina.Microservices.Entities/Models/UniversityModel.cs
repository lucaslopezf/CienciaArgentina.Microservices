using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class University
    {
        [Key]
        public int IdUniversity { get; set; }
        public Country IdCountry { get; set; }
        public string Name { get; set; }
        public int Url { get; set; }
    }
}
