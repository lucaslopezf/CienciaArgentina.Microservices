using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CienciaArgentina.Microservices.Entities.Models.Organizations;
using CienciaArgentina.Microservices.Entities.Models.User;

namespace CienciaArgentina.Microservices.Entities.Models.Commons
{
    public class SocialNetwork : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string SocialNetworkName { get; set; }
        public string UserName { get; set; }
        public string Url { get; set; }

        //TODO: Cabeceada => Pensar mejor
        public UserData UserData { get; set; }
        public Department Department { get; set; }
        public Organization Organization { get; set; }
    }
}
