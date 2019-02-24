using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models.Commons
{
    public class Telephone : BaseModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int CountryCode { get; set; }
        public int AreaCode { get; set; }
        public int PhoneNumber { get; set; }
    }
}
