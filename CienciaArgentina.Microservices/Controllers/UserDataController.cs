using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CienciaArgentina.Microservices.Data.IRepositories;
using CienciaArgentina.Microservices.Entities.Dtos;
using CienciaArgentina.Microservices.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace CienciaArgentina.Microservices.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class UserDataController : ControllerBase
    {

        private readonly IUserDataRepository _userDataRepository;

        public UserDataController(IUserDataRepository userDataRepository)
        {
            _userDataRepository = userDataRepository;
        }

        //GET api/<controller>/<userDataId>
        [HttpGet]
        [Route("{userDataId}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var userData = await _userDataRepository.Get(userId);
            if (userData == null) return NotFound();
            return Ok(userData);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDataDto userData)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = _userDataRepository.Add(Mapper.Map<UserData>(userData));
            await _userDataRepository.Save();
            return Ok(result.Result);
        }
    }
}
