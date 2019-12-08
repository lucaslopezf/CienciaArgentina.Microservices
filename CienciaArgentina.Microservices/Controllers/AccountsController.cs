using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using CienciaArgentina.Microservices.Business.Interfaces;
using CienciaArgentina.Microservices.Commons.Dtos;
using CienciaArgentina.Microservices.Commons.Dtos.User;
using CienciaArgentina.Microservices.Commons.Extensions;
using CienciaArgentina.Microservices.Commons.Mail.Interfaces;
using CienciaArgentina.Microservices.Entities.BusinessModel;
using CienciaArgentina.Microservices.Entities.Identity;
using CienciaArgentina.Microservices.Entities.QueryParameters;
using CienciaArgentina.Microservices.Persistence.Interfaces;
using CienciaArgentina.Microservices.Repositories.IRepository;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage.Messages;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CienciaArgentina.Microservices.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAccountRepository _accountRepository;
        private readonly IUserBusiness _userBusiness;
        private readonly IMapper _mapper;

        public AccountsController(IMapper mapper,UserManager<ApplicationUser> userManager, IAccountRepository accountRepository, IUserBusiness userBusiness)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
            _userBusiness = userBusiness;
            _userManager = userManager;
        }

        //GET api/<controller>
        [HttpGet]
        public IActionResult Get(QueryParameters userQueryParameters)
        {
            var allUsers = _accountRepository.Get(userQueryParameters).ToList();

            //var allUsersDto = allUsers.Select(x => Mapper.Map<UserCreateDto>(x));

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(new { totalCount = _accountRepository.Count() }));
            return Ok(allUsers);
        }

        //GET api/<controller>/5
        [HttpGet]
        //[ProducesResponseType(typeof(int), 200)]
        //[ProducesResponseType(typeof(int), 404)]
        [Route("{userName}")]
        public async Task<IActionResult> Get(string userName)
        {
            var user = await _accountRepository.Get(userName);

            if (user == null)
                return NoContent();

            return Ok(_mapper.Map<AccountDto>(user));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserCreateDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new ApplicationUser
            {
                UserName = model.UserName, Email = model.Email
            };

            var uri = UriHelper.BuildAbsolute(Request.Scheme, Request.Host);
            var result = await _userBusiness.Add(user, model.Password, uri);
            if (result.Success) return Ok(_mapper.Map<AccountDto>(user));

            return BadRequest(result);
        }

        [HttpPost]
        [Route("{addClaim}")]
        public async Task<IActionResult> AddClaim([FromBody] CreateClaimDto addClaim)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _accountRepository.Get(addClaim.ClaimType);
            var claim = new Claim(addClaim.ClaimType, addClaim.ClaimValue);
            var result = await _accountRepository.AddClaim(user, claim);

            return Ok(result);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]UserCreateDto model)
        {
            if (model == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _accountRepository.Get(id);

            if (user == null)
                return NotFound();

            Mapper.Map(model, user);

            var result = await _accountRepository.Update(user);

            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(Mapper.Map<UserCreateDto>(user));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{userName}")]
        public async Task<IActionResult> Delete(string userName)
        {
            var user = await _accountRepository.Get(userName);

            if (user == null)
                return NotFound();

            var result = await _accountRepository.Delete(user);

            if (!result.Succeeded)
                return BadRequest(result);

            return NoContent();
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> Patch(string id, [FromBody] JsonPatchDocument<UserCreateDto> userPatchDoc)
        {
            if (userPatchDoc == null)
                return BadRequest();

            var user = await _accountRepository.Get(id);

            if (user == null)
                return NotFound();

            var userToPatch = Mapper.Map<UserCreateDto>(user);
            userPatchDoc.ApplyTo(userToPatch, ModelState);

            TryValidateModel(userToPatch);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Mapper.Map(userToPatch, user);

            var result = await _accountRepository.Update(user);

            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(Mapper.Map<UserCreateDto>(user));
        }

        //
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userInfo)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var uri = UriHelper.BuildAbsolute(Request.Scheme, Request.Host);
            var result = await _userBusiness.Login(userInfo.UserName, userInfo.Password,uri);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet]
        [Route("ConfirmationRegisterMail")]
        public async Task<IActionResult> ConfirmationRegisterMail(string email,string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return NoContent();
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if(!result.Succeeded)
                return BadRequest(result);

            return Ok(result);
        }

        //TODO: Que un usuario no pueda mandar mail si no esta logueado, idem todo seguridad (Ejemplo que no pueda mandar a un tercero)
        [HttpPost]
        [Route("SendConfirmationRegisterMail")]
        public async Task<IActionResult> SendConfirmationRegisterMail(string email)
        {
            var uri = UriHelper.BuildAbsolute(Request.Scheme, Request.Host);
            var response = await _userBusiness.SendConfirmationRegisterMail(email,uri);
            
            if (!response.Success) return BadRequest(response);

            return Ok(response);
        }

        // TODO: Enviar mail con el link, NO retornar el token. Se deja sólo para testeo
        [HttpGet]
        [Route("GetPasswordResetToken")]
        public async Task<IActionResult> GetPasswordResetToken(string email)
        {
            if (string.IsNullOrEmpty(email)) return BadRequest("La el campo de e-mail no puede estar vacío");

            var response = await _userBusiness.GetPasswordResetToken(email);
            if (!response.Success) return BadRequest(response);
            
            return Ok(response);
        }

        // TODO: Enviar el mail con la confirmación
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string email, string password, string confirmPassword,
            string token)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword) ||
                string.IsNullOrEmpty(token))
                return BadRequest("Todos los campos son necesarios para el cambio de contraseña");

            if (password != confirmPassword) return BadRequest("Las contraseñas ingresadas no coinciden");

            var response = await _userBusiness.ResetPassword(email, password,confirmPassword,token);
            
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }

        // TODO: Enviar email
        [HttpGet]
        [Route("ForgotUsername")]
        public async Task<IActionResult> ForgotUsername(string email)
        {
            if (string.IsNullOrEmpty(email)) return BadRequest("El mail no puede estar vacío");

            var response = await _userBusiness.ForgotUsername(email);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}