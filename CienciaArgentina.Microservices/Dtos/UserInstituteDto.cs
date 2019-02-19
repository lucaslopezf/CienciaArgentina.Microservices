using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Dtos
{
    public class UserInstituteDto
    {
        public int Id { get; set; }
        public InstituteDto Institute { get; set; }
        public PositionDto Position { get; set; }
        public string UserId { get; set; }
    }
}
