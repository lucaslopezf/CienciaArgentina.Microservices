namespace CienciaArgentina.Microservices.Commons.Dtos
{
    public class AccountDto
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string EmailConfirmed { get; set; }
        public string NormalizedUserName { get; set; }
        public bool TwoFactorEnabled { get; set; }

        //public AccountDto(string userName,string email,string phoneNumber)
        //{
        //    UserName = userName;
        //    Email = email;
        //    PhoneNumber = phoneNumber;
        //}
    }
}
