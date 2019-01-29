using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CienciaArgentina.Microservices.Data.IRepositories;
using CienciaArgentina.Microservices.Entities.Dtos;
using CienciaArgentina.Microservices.Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CienciaArgentina.Microservices.Controllers
{
    //[ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController : Controller
    {
        private IUserRepository _userRepository;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserRepository userRepository, ILogger<UsersController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Lucas", "Nico" };
        }

        // GET api/<controller>/5
        [HttpGet]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(int), 404)]
        [Route("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation("GetUser");
            var user = _userRepository.GetSingle(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]UserCreateDto userDto)
        {
            if (userDto == null)
                return BadRequest("User object is null");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User toAdd = Mapper.Map<User>(userDto);

            _userRepository.Add(toAdd);

            bool result = _userRepository.Save();

            if (!result)
            {
                throw new Exception("Something went wrong when adding a new user");
            }

            return CreatedAtRoute("Get", new { id = toAdd.Id }, Mapper.Map<UserCreateDto>(toAdd));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
