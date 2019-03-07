using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CienciaArgentina.Microservices.Business.Interfaces;
using CienciaArgentina.Microservices.Dtos;
using CienciaArgentina.Microservices.Entities.Identity;
using CienciaArgentina.Microservices.Entities.QueryParameters;
using CienciaArgentina.Microservices.Repositories.IRepository;
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
        private readonly IConfiguration _configuration;
        private readonly IUserBusiness _userBusiness;

        public AccountsController(SignInManager<ApplicationUser> signInManager, IAccountRepository accountRepository, IUserBusiness userBusiness, IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _signInManager = signInManager;
            _configuration = configuration;
            _userBusiness = userBusiness;
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
                var result = await _userBusiness.Login(userInfo.UserName, userInfo.Password);
                if (result.Success)
                {
                    return Ok(result.JwtToken);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}