using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class Laboratory
    {
        [Key]
        public int IdLaboratory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Boss { get; set; }
        public Address IdAddress { get; set; }
        public Institute IdInstitute { get; set; }
    }
}
