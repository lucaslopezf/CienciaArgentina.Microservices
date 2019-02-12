using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CienciaArgentina.Microservices.Entities.Identity;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class UserData : EntityDateModel
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Identifier { get; set; }
        public SocialNetwork SocialNetwork { get; set; }
        public UserInstitute UserInstitute { get; set; }
        public Sex Sex { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Birthday { get; set; }
        public Address Address { get; set; }
        public WorkExperience WorkExperience { get; set; }
    }
}
