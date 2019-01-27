using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class University
    {
        public Guid Id { get; set; }
        public Country IdCountry { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
