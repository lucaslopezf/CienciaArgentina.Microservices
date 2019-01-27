using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class UserKey
    {
        [Key]
        public int IdUserKeys { get; set; }
        public User IdUser { get; set; }
        public ActionKey IdActionKey { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool Used { get; set; }
    }
}
