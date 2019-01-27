using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CienciaArgentina.Microservices.Data.IRepositories;
using CienciaArgentina.Microservices.Entities.Dtos;
using CienciaArgentina.Microservices.Entities.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CienciaArgentina.Microservices.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Lucas", "Nico" };
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
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
