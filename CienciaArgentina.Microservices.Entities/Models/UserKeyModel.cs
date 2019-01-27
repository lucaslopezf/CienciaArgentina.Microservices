using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models
{
    public class UserKey
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public ActionKey ActionKey { get; set; }
        public bool Used { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
