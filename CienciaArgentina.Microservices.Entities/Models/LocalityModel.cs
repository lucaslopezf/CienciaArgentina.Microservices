using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class Locality
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public City City { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
