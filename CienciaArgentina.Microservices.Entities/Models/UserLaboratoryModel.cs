using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CienciaArgentina.Microservices.Entities.Identity;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class UserLaboratory : EntityDateModel
    {
        [Key]
        public int Id { get; set; }
        public Laboratory Laboratory { get; set; }
        public Position Position { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
