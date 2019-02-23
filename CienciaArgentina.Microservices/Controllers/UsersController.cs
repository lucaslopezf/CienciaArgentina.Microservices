using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CienciaArgentina.Microservices.Entities.Dtos;
using CienciaArgentina.Microservices.Entities.Models;
using CienciaArgentina.Microservices.Entities.QueryParameters;
using CienciaArgentina.Microservices.Repositories.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CienciaArgentina.Microservices.Controllers
{
    //[ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController : Controller
    {
        private IAccountRepository _userRepository;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IAccountRepository userRepository, ILogger<UsersController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        // GET api/<controller>
        [HttpGet]
        public IActionResult Get(QueryParameters userQueryParameters)
        {
            var allUsers = _userRepository.Get(userQueryParameters).ToList();

            var allUsersDto = allUsers.Select(x => Mapper.Map<UserCreateDto>(x));

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(new { totalCount = _userRepository.Count() }));

            return Ok(allUsersDto);
        }

        //// GET api/<controller>/5
        //[HttpGet]
        //[ProducesResponseType(typeof(int), 200)]
        //[ProducesResponseType(typeof(int), 404)]
        //[Route("{id}", Name = "Get")]
        //public IActionResult Get(int id)
        //{
        //    _logger.LogInformation("GetUser");
        //    var user = _userRepository.Get(id);

        //    if (user == null)
        //        return NotFound();

        //    return Ok(user);
        //}

        //// POST api/<controller>
        //[HttpPost]
        //public IActionResult Post([FromBody]UserCreateDto userDto)
        //{
        //    if (userDto == null)
        //        return BadRequest("User object is null");

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    User toAdd = Mapper.Map<User>(userDto);

        //    _userRepository.Add(toAdd);

        //    bool result = _userRepository.Save();

        //    if (!result)
        //    {
        //        throw new Exception("Something went wrong when adding a new user");
        //    }

        //    return CreatedAtRoute("Get", new { id = toAdd.Id }, Mapper.Map<UserCreateDto>(toAdd));
        //}

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody]UserCreateDto model)
        //{
        //    if (model == null)
        //    {
        //        return BadRequest();
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var existingUser = _userRepository.Get(id);

        //    if (existingUser == null)
        //    {
        //        return NotFound();
        //    }


        //    Mapper.Map(model, existingUser);

        //    _userRepository.Update(existingUser);

        //    bool result = _userRepository.Save();

        //    if (!result)
        //    {
        //        throw new Exception($"something went wrong when updating the user with id: {id}");
        //    }

        //    return Ok(Mapper.Map<UserCreateDto>(existingUser));
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var existingUser = _userRepository.Get(id);

        //    if (existingUser == null)
        //    {
        //        return NotFound();
        //    }

        //    _userRepository.Delete(id);

        //    bool result = _userRepository.Save();

        //    if (!result)
        //    {
        //        throw new Exception($"something went wrong when deleting the user with id: {id}");
        //    }

        //    return NoContent();
        //}

        //[HttpPatch]
        //[Route("{id}")]
        //public IActionResult Patch(int id, [FromBody] JsonPatchDocument<UserCreateDto> userPatchDoc)
        //{
        //    if (userPatchDoc == null)
        //    {
        //        return BadRequest();
        //    }

        //    var existingUser = _userRepository.Get(id);

        //    if (existingUser == null)
        //    {
        //        return NotFound();
        //    }

        //    var customerToPatch = Mapper.Map<UserCreateDto>(existingUser);
        //    userPatchDoc.ApplyTo(customerToPatch, ModelState);

        //    TryValidateModel(customerToPatch);

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Mapper.Map(customerToPatch, existingUser);

        //    _userRepository.Update(existingUser);

        //    bool result = _userRepository.Save();

        //    if (!result)
        //    {
        //        throw new Exception($"something went wrong when updating the user with id: {id}");
        //    }

        //    return Ok(Mapper.Map<UserCreateDto>(existingUser));
        //}
    }
}
