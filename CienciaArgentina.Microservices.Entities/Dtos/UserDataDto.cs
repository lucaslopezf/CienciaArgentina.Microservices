using System;
using System.Collections.Generic;
using System.Text;
using CienciaArgentina.Microservices.Entities.Models;

namespace CienciaArgentina.Microservices.Entities.Dtos
{
    public class UserDataDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Identifier { get; set; }
        public SocialNetworkDto SocialNetwork { get; set; }
        public DateTime Birthday { get; set; }
    }
}
