using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Business.Interfaces;
using CienciaArgentina.Microservices.Commons.Mail.Interfaces;
using CienciaArgentina.Microservices.Commons.Mail.ModelTemplates;
using CienciaArgentina.Microservices.Entities.BusinessModel;
using CienciaArgentina.Microservices.Entities.Identity;
using CienciaArgentina.Microservices.Repositories.IRepository;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage.Messages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace CienciaArgentina.Microservices.Business.Implementation
{
    public class UserBusiness : IUserBusiness
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAccountRepository _accountRepository;
        private readonly IEmailClientSender _emailClientSender;

        public UserBusiness(SignInManager<ApplicationUser> signInManager, IAccountRepository accountRepository, IEmailClientSender emailClientSender)
        {
            _accountRepository = accountRepository;
            _signInManager = signInManager;
            _emailClientSender = emailClientSender;
        }

        public async Task<LoginModel> Add(ApplicationUser user, string password,string uri)
        {
            var result = await _accountRepository.Add(user, password);
            var response = new LoginModel
            {
                Success = result.Succeeded
            };
            if (result.Succeeded)
            {
                response.JwtToken = BuildToken(user.UserName, user.Email);
                await SendEmailConfirmationAsync(user, uri);
            }
            else
                response.Message = "Error al agregar el usuario";

            return response;
        }

        public async Task<LoginModel> Login(string userName, string password,string uri)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, isPersistent: false, lockoutOnFailure: false);
            var response = new LoginModel
            {
                Success = result.Succeeded
            };
            if (result.Succeeded)
            {
                var user = await _accountRepository.Get(userName);
                if (!await _accountRepository.IsEmailConfirmedAsync(user))
                {
                    await SendEmailConfirmationAsync(user,uri);
                    response.Success = false;
                    response.Message = "Por favor debe confirmar la cuenta. Revisa el correo electronico.";
                }
                else
                    response.JwtToken = BuildToken(user.UserName,user.Email);
            }
            else
            {
                //TODO: Configuration Message
                response.Message = "Contraseña incorrecta";
            }

            return response;
        }

        public async Task SendEmailConfirmationAsync(ApplicationUser user,string uri)
        {
                var tokenConfirmation = await _accountRepository.GenerateEmailConfirmationTokenAsync(user);
                var api = "api/Accounts/ConfirmationRegisterMail";
                var url = $"{uri}{api}?email={user.Email}&token={tokenConfirmation}";
                url = url.Replace("+", "%2B");
                var sendConfirmationModel = new SendConfirmationAccountModel(user.UserName, "", url);
                await _emailClientSender.SendConfirmationAccounEmail(user.Email, sendConfirmationModel);
        }

        private JwtToken BuildToken(string userName, string email)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userName),
                new Claim(JwtRegisteredClaimNames.UniqueName, email),
                //new Claim("miValor", "Lo que yo quiera"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            //TODO: Configuration
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asdadsasdQWEDASsasd123Ss"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            var token = new JwtSecurityToken(
                issuer: "cienciaArgentina",//_configuration["ApiAuthJWT:Issuer"],
                audience: "cienciaArgentina", //_configuration["ApiAuthJWT:Audience"],
                claims: claims,
                expires: expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: creds);

            var jwtToken = new JwtToken(new JwtSecurityTokenHandler().WriteToken(token), expiration);
            return jwtToken;
        }
    }
}
