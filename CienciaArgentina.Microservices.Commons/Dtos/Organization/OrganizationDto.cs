using System;
using System.Collections.Generic;
using System.Text;
using CienciaArgentina.Microservices.Commons.Dtos;
using CienciaArgentina.Microservices.Entities;

namespace CienciaArgentina.Microservices.Commons.Dtos.Organization
{
    public class OrganizationDto
    {
        public string Name { get; set; }
        public string Initials { get; set; }
        public OrganizationTypeDto OrganizationType { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public string DescriptionLarge { get; set; }
        public string Link { get; set; }
        public AddressDto Address { get; set; }
    }
}
