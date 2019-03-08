namespace CienciaArgentina.Microservices.Commons.Dtos
{
    public class AccountDto
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public int AccessFailedCount { get; set; }
    }
}
