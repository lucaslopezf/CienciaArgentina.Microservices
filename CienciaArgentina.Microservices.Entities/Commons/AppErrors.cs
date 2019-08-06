using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.BusinessModel
{
    public class AppErrors
    {
        public static readonly ErrorResponseModel EmailNotConfirmed = 
            new ErrorResponseModel("Confirmar email","Por favor debe confirmar la cuenta. Revisa el correo electronico.");

        public static readonly ErrorResponseModel PasswordIncorrect =
            new ErrorResponseModel("Contraseña y/o usuario incorrectos", "No reconocemos ningun usuario y/o contraseña en nuestro sistema");









    }
}
