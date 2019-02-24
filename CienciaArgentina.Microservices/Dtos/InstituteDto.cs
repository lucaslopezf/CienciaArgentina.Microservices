using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Dtos
{
    public class OrganizationDto
    {
        public string Name { get; set; }
        public string Initials { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public string DescriptionLarge { get; set; }
        public string Link { get; set; }
        public AddressDto Address { get; set; }
    }
}
