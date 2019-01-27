using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class SocialNetwork
    {
        public int Id { get; set; }
        public string SocialNetworkName { get; set; }
        public string UserName { get; set; }
        public string Url { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public User IdUser { get; set; }
    }
}
