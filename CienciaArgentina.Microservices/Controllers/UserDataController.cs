﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CienciaArgentina.Microservices.Data.IRepositories;
using CienciaArgentina.Microservices.Entities.Dtos;
using CienciaArgentina.Microservices.Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDataDto body)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = _userDataRepository.Add(Mapper.Map<UserData>(body));
            await _userDataRepository.Save();
            return Ok(result.Result);
        }

        // PUT api/<controller>/<userDataId>
        [HttpPut("{userDataId}")]
        public async Task<IActionResult> Put(Guid userId, [FromBody] UserDataDto body)
        {
            if (body == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userData = await _userDataRepository.Get(userId);

            if (userData == null)
                return NotFound();

            Mapper.Map(body, userData);

            _userDataRepository.Update(userData);

            return Ok(userData);
        }

        // DELETE api/<controller>/<userDataId>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userData = await _userDataRepository.Get(id);

            if (userData == null)
                return NotFound();

            _userDataRepository.Delete(userData);
            
            return NoContent();
        }

        // PATCH api/<controller>/<userDataId>
        [HttpPatch]
        [Route("{iduserDataId}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<UserDataDto> userDataDto)
        {
            if (userDataDto == null)
                return BadRequest();

            var userData = await _userDataRepository.Get(id);

            if (userData == null)
                return NotFound();

            var userToPatch = Mapper.Map<UserDataDto>(userData);
            userDataDto.ApplyTo(userToPatch, ModelState);

            TryValidateModel(userToPatch);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Mapper.Map(userToPatch, userData);

            _userDataRepository.Update(userData);

            return Ok(Mapper.Map<UserDataDto>(userData));
        }
    }
}
