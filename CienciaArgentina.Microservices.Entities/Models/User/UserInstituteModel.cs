using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CienciaArgentina.Microservices.Entities.Identity;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class UserInstitute : EntityDateModel
    {
        [Key]
        public int Id { get; set; }
        public Institute Institute { get; set; }
        public Position Position { get; set; }

        //For identity
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
