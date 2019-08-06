using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using CienciaArgentina.Microservices.Business.Application.Papers;
using CienciaArgentina.Microservices.Commons.Helpers.Date;
using CienciaArgentina.Microservices.Commons.Dtos;
using CienciaArgentina.Microservices.Entities.Models;
using CienciaArgentina.Microservices.Entities.Models.User;
using CienciaArgentina.Microservices.Repositories.IUoW;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage.Messages;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;

namespace CienciaArgentina.Microservices.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET api/<controller>/<usersData>
        [HttpGet]
        [Route("{userProfileId}")]
        public async Task<IActionResult> Get(int userId)
        {
            var userProfile = await _unitOfWork.Repository<UserProfile>().GetByIdAsync(userId);
            if (userProfile == null) return NotFound();
            return Ok(userProfile);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserProfileDto body)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _unitOfWork.Repository<UserProfile>().AddAsync(Mapper.Map<UserProfile>(body));
            await _unitOfWork.Commit();
            return Ok(result.Id);
        }

        // PUT api/<controller>/<userProfileId>
        [HttpPut("{userProfileId}")]
        public async Task<IActionResult> Put(int userId, [FromBody] UserProfileDto body)
        {
            if (body == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userProfile = await _unitOfWork.Repository<UserProfile>().GetByIdAsync(userId);

            if (userProfile == null)
                return NotFound();

            Mapper.Map(body, userProfile);

            _unitOfWork.Repository<UserProfile>().Update(userProfile);

            return Ok(userProfile);
        }

        // DELETE api/<controller>/<userProfileId>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userProfile = await _unitOfWork.Repository<UserProfile>().GetByIdAsync(id);

            if (userProfile == null)
                return NotFound();

            _unitOfWork.Repository<UserProfile>().Delete(userProfile);
            
            return NoContent();
        }

        // PATCH api/<controller>/<userProfileId>
        [HttpPatch]
        [Route("{userProfileId}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<UserProfileDto> userProfileDto)
        {
            if (userProfileDto == null)
                return BadRequest();

            var userProfile = await _unitOfWork.Repository<UserProfile>().GetByIdAsync(id);

            if (userProfile == null)
                return NotFound();

            var userToPatch = Mapper.Map<UserProfileDto>(userProfile);
            userProfileDto.ApplyTo(userToPatch, ModelState);

            TryValidateModel(userToPatch);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Mapper.Map(userToPatch, userProfile);

            _unitOfWork.Repository<UserProfile>().Update(userProfile);

            return Ok(Mapper.Map<UserProfileDto>(userProfile));
        }

        // TODO: Esto realmente va acá?
        // Example: PMID = 29519839
        [HttpGet]
        [Route("GetArticleByPMID/{pmid}")]
        public async Task<IActionResult> GetArticleByPMID(int? pmid)
        {
            if (pmid == null)
                return BadRequest();

            var paper = await PapersWrapper.Get(pmid);

            if (paper == null)
                return NotFound();

            return Ok(paper);
        }

        [HttpGet]
        [Route("GetArticlesByAlias/{alias}")]
        public async Task<IActionResult> GetArticlesByAlias(string alias)
        {
            if (alias == null)
                return BadRequest();

            var papers = await PapersWrapper.Get(alias);

            if (papers == null)
                return NotFound();

            return Ok(papers);
        }
    }
}
