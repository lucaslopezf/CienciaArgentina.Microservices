using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class Country : EntityDateModel
    {
        [Key]
        public int Id { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        public string Name { get; set; }
    }
}
