using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CienciaArgentina.Microservices.Entities.Identity;
using CienciaArgentina.Microservices.Entities.Models.Addresses;
using CienciaArgentina.Microservices.Entities.Models.Commons;

namespace CienciaArgentina.Microservices.Entities.Models.User
{
    public class UserProfileImageModel : BaseModel
    {
        [Key]
        public int Id { get; set; }
        
        public string Type { get; set; }

        public string Description { get; set; }
        public string Url { get; set; }
        public bool IsPublic { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
