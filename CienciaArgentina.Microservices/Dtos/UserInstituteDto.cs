using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Dtos
{
    public class UserOrganizationDto
    {
        public int Id { get; set; }
        public OrganizationDto Organization { get; set; }
        public PositionDto Position { get; set; }
        public string UserId { get; set; }
    }
}
