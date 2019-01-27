using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class UserKeys
    {
        public int Id { get; set; }
        public User IdUser { get; set; }
        public ActionKey IdActionKey { get; set; }
        public DateTime DateFrom { get; set; }
        public bool Used { get; set; }
        public DateTime DateTo { get; set; }
    }
}
