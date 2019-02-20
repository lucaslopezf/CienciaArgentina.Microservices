using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Dtos
{
    public class AddressDto
    {public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string ZipCode { get; set; }
        public string Department { get; set; }
        public string Additionals { get; set; }
        public int LocalityId { get; set; }
		public int Prueba { get; set; }
    }
}
