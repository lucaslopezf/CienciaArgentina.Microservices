using CienciaArgentina.Microservices.Entities.BusinessModel;

namespace CienciaArgentina.Microservices.Entities.Commons
{
    public class AppErrors
    {
        public static readonly ErrorResponseModel EmailNotConfirmed = 
            new ErrorResponseModel("EmailNotConfirmed", "Por favor debe confirmar la cuenta de email");

        public static readonly ErrorResponseModel EmailIsConfirmed =
            new ErrorResponseModel("EmailIsConfirmed", "El mail ya esta confirmado");

        public static readonly ErrorResponseModel PasswordOrUserIncorrect =
            new ErrorResponseModel("PasswordOrUserIncorrect", "No reconocemos ningun usuario y/o contraseña en nuestro sistema");
    }
}
