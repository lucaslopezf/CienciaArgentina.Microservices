using CienciaArgentina.Microservices.Commons.Dtos.Organization;

namespace CienciaArgentina.Microservices.Commons.Dtos.User
{
    public class UserOrganizationDto
    {
        public int Id { get; set; }
        public OrganizationDto Organization { get; set; }
        public PositionDto Position { get; set; }
        public string UserId { get; set; }
    }
}
