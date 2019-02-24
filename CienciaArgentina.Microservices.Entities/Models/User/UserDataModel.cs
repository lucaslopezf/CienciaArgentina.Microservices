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
    public class UserData : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string IdentifierType { get; set; }
        public string Identifier { get; set; }
        public SocialNetwork SocialNetwork { get; set; }
        public UserOrganization UserOrganization { get; set; }
        public Sex Sex { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Birthday { get; set; }
        public Address Address { get; set; }
        public Country Nationality { get; set; }
        public List<WorkExperience> WorkExperience { get; set; }
        public List<Telephone> Telephone { get; set; }

        //For identity
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
