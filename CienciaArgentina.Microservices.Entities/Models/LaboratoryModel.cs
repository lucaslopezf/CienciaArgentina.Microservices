using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class Laboratory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Boss { get; set; }
        public Address IdAddress { get; set; }
        public Institute IdInstitute { get; set; }
    }
}
