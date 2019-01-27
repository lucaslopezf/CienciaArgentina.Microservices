using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class User
    {
        [Key]
        public Guid IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserData IdUserData { get; set; }
        public Role IdRole { get; set; }
        public bool Blocked { get; set; }
        public bool Confirmed { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
