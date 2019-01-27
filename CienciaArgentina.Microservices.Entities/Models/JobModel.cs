using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class Job
    {
        public Guid Id { get; set; }
        public string Company { get; set; }
        public string Charge { get; set; }
        public string Description { get; set; }
        public string Addittions { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
