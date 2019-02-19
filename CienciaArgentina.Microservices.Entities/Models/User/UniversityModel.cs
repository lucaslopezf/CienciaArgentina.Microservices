using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CienciaArgentina.Microservices.Entities.Models.Addresses;

namespace CienciaArgentina.Microservices.Entities.Models.User
{
    public class University : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public Address Address { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
