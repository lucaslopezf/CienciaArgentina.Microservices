using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using CienciaArgentina.Microservices.Business.Interfaces;
using CienciaArgentina.Microservices.Commons.Dtos;
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
        public AccountsController(UserManager<ApplicationUser> userManager, IAccountRepository accountRepository, IUserBusiness userBusiness)
        {
            _accountRepository = accountRepository;
            _userBusiness = userBusiness;
            _userManager = userManager;
        }

        //GET api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get(QueryParameters userQueryParameters)
        {
            var allUsers = _accountRepository.Get(userQueryParameters).ToList();

            //var allUsersDto = allUsers.Select(x => Mapper.Map<UserCreateDto>(x));

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(new { totalCount = _accountRepository.Count() }));
            return Ok(allUsers);
        }

        //GET api/<controller>/5
        [HttpGet]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(int), 404)]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _accountRepository.Get(id);

            if (user == null)
                return NoContent();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserCreateDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var uri = UriHelper.BuildAbsolute(Request.Scheme, Request.Host);
            var result = await _userBusiness.Add(user, model.Password,uri);
            if (result.Response.Success) return Ok(model);

            return BadRequest(result.Response.Errors);
        }

        [HttpPost]
        [Route("{addClaim}")]
        public async Task<IActionResult> AddClaim([FromBody] CreateClaimDto addClaim)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _accountRepository.Get(addClaim.ClaimType);
            var claim = new Claim(addClaim.ClaimType, addClaim.ClaimValue);
            var result = await _accountRepository.AddClaim(user, claim);

            return Ok(result.Succeeded);
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
                return BadRequest(result.Errors);

            return Ok(Mapper.Map<UserCreateDto>(user));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _accountRepository.Get(id);

            if (user == null)
                return NotFound();

            var result = await _accountRepository.Delete(user);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

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
                return BadRequest(result.Errors);

            return Ok(Mapper.Map<UserCreateDto>(user));
        }

        //
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserCreateDto userInfo)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var uri = UriHelper.BuildAbsolute(Request.Scheme, Request.Host);
            var result = await _userBusiness.Login(userInfo.UserName, userInfo.Password,uri);
            if (result.Response.Success)
            {
                return Ok(result.JwtToken);
            }

            return BadRequest(result.Response.Errors);
        }

        [HttpGet]
        [Route("ConfirmationRegisterMail")]
        public async Task<IActionResult> ConfirmationRegisterMail(string email,string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return NoContent();
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if(!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok("Usuario verificado");
        }
    }
}