using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Models.Addresses
{
    public class Address : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string ZipCode { get; set; }
        public string Department { get; set; }
        public string Additionals { get; set; }
        public Locality Locality { get; set; }
    }
}
