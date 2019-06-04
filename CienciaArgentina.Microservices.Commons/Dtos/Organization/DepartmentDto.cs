using System;
using System.Collections.Generic;
using System.Text;
using CienciaArgentina.Microservices.Commons.Dtos;
using CienciaArgentina.Microservices.Entities;

namespace CienciaArgentina.Microservices.Commons.Dtos.Organization
{
    public class DepartmentDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public OrganizationDto Organization { get; set; }
        public AddressDto Address { get; set; }
    }
}
