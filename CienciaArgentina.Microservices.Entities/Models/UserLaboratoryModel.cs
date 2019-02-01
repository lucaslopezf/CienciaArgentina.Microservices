using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CienciaArgentina.Microservices.Entities.Identity;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class UserLaboratory
    {
        [Key]
        public int Id { get; set; }
        public Laboratory Laboratory { get; set; }
        public Role Role { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
