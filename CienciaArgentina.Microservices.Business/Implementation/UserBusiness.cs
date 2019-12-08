using System;
using System.IdentityModel.Tokens.Jwt;
//using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Business.Interfaces;
using CienciaArgentina.Microservices.Commons.Dtos;
using CienciaArgentina.Microservices.Commons.Mail.Interfaces;
using CienciaArgentina.Microservices.Commons.Mail.ModelTemplates;
using CienciaArgentina.Microservices.Entities.BusinessModel;
using CienciaArgentina.Microservices.Entities.Commons;
using CienciaArgentina.Microservices.Entities.Identity;
using CienciaArgentina.Microservices.Repositories.IRepository;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage.Messages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        public async Task<ResponseModel<LoginModel>> Add(ApplicationUser user, string password,string uri)
        {
            var result = await _accountRepository.Add(user, password);
            var loginModel = new LoginModel(user.Email);
            var response = new ResponseModel<LoginModel>(loginModel,result.Succeeded);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    response.AddError(new ErrorResponseModel(error.Code, error.Description));
                
                return response;
            }

            var token = BuildToken(user.UserName, user.Email);
            response.Data.AddToken(token);
            await SendEmailConfirmationAsync(user, uri);

            return response;
        }

        public async Task<ResponseModel<LoginModel>> SendConfirmationRegisterMail(string email,string uri)
        {
            var user = await _accountRepository.GetByEmail(email);
            var loginModel = new LoginModel(email);
            var response = new ResponseModel<LoginModel>(loginModel);

            if (user != null) return await SendEmailConfirmationAsync(user, uri);

            response.AddError(AppErrors.PasswordOrUserIncorrect);
            return response;

        }

        public async Task<ResponseModel<LoginModel>> Login(string userName, string password,string uri, bool isPersistent = false, bool lockoutOnFailure = false)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
            var responseModel = new ResponseModel<LoginModel>(result.Succeeded);

            if (!result.Succeeded)
            {
                responseModel.AddError(AppErrors.PasswordOrUserIncorrect);
                return responseModel;
            }

            var user = await _accountRepository.Get(userName);
            var loginModel = new LoginModel(user.Email);
            responseModel.Data = loginModel;

            if (!await _accountRepository.IsEmailConfirmedAsync(userName))
            {  
                responseModel.Success = false;
                responseModel.AddError(AppErrors.EmailNotConfirmed);
                
                return responseModel;
            }
            
            var token = BuildToken(user.UserName, user.Email);

            responseModel.Data.AddToken(token);
            return responseModel;
        }

        public async Task<ResponseModel<LoginModel>> SendEmailConfirmationAsync(ApplicationUser user,string uri)
        {
            var responseModel = new ResponseModel<LoginModel>(new LoginModel(user.Email));

            if (await _accountRepository.IsEmailConfirmedAsync(user))
            {
                responseModel.AddError(AppErrors.EmailIsConfirmed);
                return responseModel;
            }

            var tokenConfirmation = await _accountRepository.GenerateEmailConfirmationTokenAsync(user);
            var api = "/ConfirmationRegisterMail";
            var webAppUrl = "https://cienciaargentina.com";
            var url = $"{webAppUrl}{api}/ConfirmationRegisterMail?email={user.Email}&token={tokenConfirmation}";
            url = url.Replace("+", "%2B");
            var sendConfirmationModel = new SendConfirmationAccountModel(user.UserName, "", url);
            await _emailClientSender.SendConfirmationAccountEmail(user.Email, sendConfirmationModel);
            responseModel.Success = true;
            return responseModel;
        }

        public async Task<ResponseModel<LoginModel>> ForgotUsername(string email)
        {
            var user = await _accountRepository.GetByEmail(email);
            var responseModel = new ResponseModel<LoginModel>(user != null);

            if (!responseModel.Success)
            {
               responseModel.AddError(AppErrors.PasswordOrUserIncorrect);
               return responseModel;
            }

            await _emailClientSender.SendForgotUser(user.Email, new SendForgotUserModel(user.UserName));
            return responseModel;
        }

        public async Task<ResponseModel<LoginModel>> GetPasswordResetToken(string email)
        {
            var user = await _accountRepository.GetByEmail(email);
            var loginModel = new LoginModel(email);
            var response = new ResponseModel<LoginModel>(loginModel);
            if (user == null)
            {
                response.AddError(AppErrors.PasswordOrUserIncorrect);
                return response;
            }

            var token = await _accountRepository.GeneratePasswordResetTokenAsync(user);

            var api = "/ConfirmationRegisterMail";
            var webAppUrl = "https://cienciaargentina.com";
            var url = $"www.MATIASCODEAESTO={user.Email}&token={token}";
            url = url.Replace("+", "%2B");

            await _emailClientSender.SendGetPasswordResetToken(email,new SendGetPasswordResetTokenModel(user.UserName,url));
            return response;
        }

        public async Task<ResponseModel<LoginModel>> ResetPassword(string email, string password, string confirmPassword,
            string token)
        {
            var user = await _accountRepository.GetByEmail(email);
            var loginModel = new LoginModel(email);
            var response = new ResponseModel<LoginModel>(loginModel);

            if (user == null)
            {
                response.AddError(AppErrors.PasswordOrUserIncorrect);
                return response;
            }

            var result = await _accountRepository.ResetPassword(user, token, password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    response.AddError(new ErrorResponseModel(error.Code, error.Description));

                return response;
            }

            await _emailClientSender.SendConfirmationResetPassword(user.Email,new SendResetPasswordModel(user.UserName));

            response.Success = true;
            return response;
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
