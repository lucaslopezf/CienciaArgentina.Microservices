using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models.Commons
{
    public class SocialNetwork : EntityDateModel
    {
        [Key]
        public int Id { get; set; }
        public string SocialNetworkName { get; set; }
        public string UserName { get; set; }
        public string Url { get; set; }
    }
}
