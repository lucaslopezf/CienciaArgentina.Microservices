using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CienciaArgentina.Microservices.Data;
using CienciaArgentina.Microservices.Data.IRepositories;
using CienciaArgentina.Microservices.Data.Repositories;
using CienciaArgentina.Microservices.Entities.Dtos;
using CienciaArgentina.Microservices.Entities.Identity;
using CienciaArgentina.Microservices.Entities.QueryParameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CienciaArgentina.Microservices.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<AccountsController> _logger;
        private readonly IConfiguration _configuration;

        public AccountsController(SignInManager<ApplicationUser> signInManager, IAccountRepository accountRepository, ILogger<AccountsController> logger, IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _logger = logger;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        //GET api/<controller>
        [HttpGet]
        public IActionResult Get(QueryParameters userQueryParameters)
        {
            var allUsers = _accountRepository.Get(userQueryParameters).ToList();

            var allUsersDto = allUsers.Select(x => Mapper.Map<UserCreateDto>(x));

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(new { totalCount = _accountRepository.Count() }));

            return Ok(allUsersDto);
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
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserCreateDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new ApplicationUser
            {
                UserName = model.UserName,
            };

            var result = await _accountRepository.Add(user, model.Password);

            // Let Identity handle the possible error messages output
            return result.Succeeded ? BuildToken(model) : BadRequest(result.Errors);
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
                throw new Exception($"something went wrong when updating the user with id: {id}");

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
                throw new Exception($"something went wrong when deleting the user with id: {id}");

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
                throw new Exception($"something went wrong when updating the user with id: {id}");

            return Ok(Mapper.Map<UserCreateDto>(user));
        }

        //
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserCreateDto userInfo)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userInfo.UserName, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return BuildToken(userInfo);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //TODO: BuildToken debe ir en otro lugar?
        private IActionResult BuildToken(UserCreateDto userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
                //new Claim("miValor", "Lo que yo quiera"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["ApiAuthJWT:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            var token = new JwtSecurityToken(
               issuer: _configuration["ApiAuthJWT:Issuer"],
               audience: _configuration["ApiAuthJWT:Audience"],
               claims: claims,
               expires: expiration,
               notBefore: DateTime.UtcNow,
               signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration
            });
        }
    }
}