using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models.Addresses
{
    public class Country : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Iso2 { get; set; }
        public string Iso3 { get; set; }
        public string Name { get; set; }
    }
}
