using System;
using System.Collections.Generic;
using System.Text;
using CienciaArgentina.Microservices.Commons.Dtos.Organization;
using CienciaArgentina.Microservices.Entities;

namespace CienciaArgentina.Microservices.Commons.Dtos
{
    public class UserOrganizationDto
    {
        public int Id { get; set; }
        public OrganizationDto Organization { get; set; }
        public PositionDto Position { get; set; }
        public string UserId { get; set; }
    }
}
