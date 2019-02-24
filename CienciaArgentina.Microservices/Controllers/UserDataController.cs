using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using CienciaArgentina.Microservices.Commons.Helpers;
using CienciaArgentina.Microservices.Dtos;
using CienciaArgentina.Microservices.Entities.Dtos;
using CienciaArgentina.Microservices.Entities.Models;
using CienciaArgentina.Microservices.Entities.Models.User;
using CienciaArgentina.Microservices.Repositories.IUoW;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;

namespace CienciaArgentina.Microservices.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class UserDataController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserDataController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET api/<controller>/<userDataId>
        [HttpGet]
        [Route("{userDataId}")]
        public async Task<IActionResult> Get(int userId)
        {
            var userData = await _unitOfWork.Repository<UserData>().GetByIdAsync(userId);
            if (userData == null) return NotFound();
            return Ok(userData);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDataDto body)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _unitOfWork.Repository<UserData>().AddAsync(Mapper.Map<UserData>(body));
            await _unitOfWork.Commit();
            var a = DateTimeHelper.Now;
            return Ok(result.Id);
        }

        // PUT api/<controller>/<userDataId>
        [HttpPut("{userDataId}")]
        public async Task<IActionResult> Put(int userId, [FromBody] UserDataDto body)
        {
            if (body == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userData = await _unitOfWork.Repository<UserData>().GetByIdAsync(userId);

            if (userData == null)
                return NotFound();

            Mapper.Map(body, userData);

            _unitOfWork.Repository<UserData>().Update(userData);

            return Ok(userData);
        }

        // DELETE api/<controller>/<userDataId>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userData = await _unitOfWork.Repository<UserData>().GetByIdAsync(id);

            if (userData == null)
                return NotFound();

            _unitOfWork.Repository<UserData>().Delete(userData);
            
            return NoContent();
        }

        // PATCH api/<controller>/<userDataId>
        [HttpPatch]
        [Route("{iduserDataId}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<UserDataDto> userDataDto)
        {
            if (userDataDto == null)
                return BadRequest();

            var userData = await _unitOfWork.Repository<UserData>().GetByIdAsync(id);

            if (userData == null)
                return NotFound();

            var userToPatch = Mapper.Map<UserDataDto>(userData);
            userDataDto.ApplyTo(userToPatch, ModelState);

            TryValidateModel(userToPatch);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Mapper.Map(userToPatch, userData);

            _unitOfWork.Repository<UserData>().Update(userData);

            return Ok(Mapper.Map<UserDataDto>(userData));
        }
    }
}
