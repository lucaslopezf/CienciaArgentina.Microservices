using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.Dtos
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "Por favor ingresa un nombre de usuario")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Por favor ingresa una contraseña")]
        public string Password { get; set; }
    }
}
