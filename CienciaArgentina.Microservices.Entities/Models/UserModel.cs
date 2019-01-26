using System;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Confirmed { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool Blocked { get; set; }
    }
}