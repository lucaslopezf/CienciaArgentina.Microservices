namespace CienciaArgentina.Microservices.Commons.Dtos
{
    public class CreateClaimDto
    {
        public string TypeName { get; set; } //Role || user
        public string ClaimType{ get; set; }
        public string ClaimValue { get; set; }
    }
}
