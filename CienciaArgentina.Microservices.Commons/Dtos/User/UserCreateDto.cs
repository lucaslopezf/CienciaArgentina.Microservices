using System.ComponentModel.DataAnnotations;

namespace CienciaArgentina.Microservices.Commons.Dtos.User
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "Por favor ingresa un nombre de usuario")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Por favor ingresa una contraseña")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Por favor ingresa un email")]
        public string Email { get; set; }

    }
}
