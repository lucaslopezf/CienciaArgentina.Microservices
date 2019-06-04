using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CienciaArgentina.Microservices.Commons.Dtos;
using CienciaArgentina.Microservices.Commons.Helpers.Date;
using CienciaArgentina.Microservices.Entities.Models.JobOffer;
using CienciaArgentina.Microservices.Repositories.IUoW;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CienciaArgentina.Microservices.Controllers
{
    [Route("api/[controller]")]
    public class JobOffersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobOffersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var jobs = await _unitOfWork.Repository<JobOffer>().GetAllAsync();
            if (jobs == null) return NotFound();
            return Ok(jobs);
        }

        //GET api/<controller>/<jobOfferId>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var job = await _unitOfWork.Repository<JobOffer>().GetByIdAsync(id);
            if (job == null) return NotFound();
            return Ok(job);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobOfferDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _unitOfWork.Repository<JobOffer>().AddAsync(Mapper.Map<JobOffer>(model));
            await _unitOfWork.Commit();
            return Ok(result.Id);
        }

        // PUT api/<controller>/<jobOfferId>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] JobOfferDto body)
        {
            if (body == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var jobOffer = await _unitOfWork.Repository<JobOffer>().GetByIdAsync(id);

            if (jobOffer == null)
                return NotFound();

            Mapper.Map(body, jobOffer);
            _unitOfWork.Repository<JobOffer>().Update(jobOffer);
            return Ok(jobOffer);
        }

        // PATCH api/<controller>/<jobOfferId>
        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<JobOfferDto> body)
        {
            if (body == null)
                return BadRequest();

            var jobOffer = await _unitOfWork.Repository<JobOffer>().GetByIdAsync(id);

            if (jobOffer == null)
                return NotFound();

            var patchJobOffer = Mapper.Map<JobOfferDto>(jobOffer);
            body.ApplyTo(patchJobOffer, ModelState);
            TryValidateModel(patchJobOffer);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Mapper.Map(patchJobOffer, jobOffer);
            _unitOfWork.Repository<JobOffer>().Update(jobOffer);
            return Ok(Mapper.Map<JobOfferDto>(jobOffer));
        }

        // DELETE api/<controller>/<jobOfferId>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var jobOffer = await _unitOfWork.Repository<JobOffer>().GetByIdAsync(id);

            if (jobOffer == null)
                return NotFound();

            _unitOfWork.Repository<JobOffer>().Delete(jobOffer);
            return NoContent();
        }

    }
}
