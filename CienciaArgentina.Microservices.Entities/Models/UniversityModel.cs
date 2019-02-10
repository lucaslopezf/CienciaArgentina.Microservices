using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class University
    {
        [Key]
        public int Id { get; set; }
        public Address Address { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
