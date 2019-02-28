using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CienciaArgentina.Microservices.Commons.Helpers.Date;
using CienciaArgentina.Microservices.Dtos;
using CienciaArgentina.Microservices.Dtos.Organization;
using CienciaArgentina.Microservices.Entities.Models.Organizations;
using CienciaArgentina.Microservices.Entities.Models.User;
using CienciaArgentina.Microservices.Repositories.IUoW;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CienciaArgentina.Microservices.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class OrganizationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrganizationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var organizations = await _unitOfWork.Repository<Organization>().GetAllAsync();
            if (organizations == null) return NotFound();
            return Ok(organizations);
        }

        //GET api/<controller>/<organizationId>
        [HttpGet]
        [Route("{organizationId}")]
        public async Task<IActionResult> Get(int organizationId)
        {
            var organizations = await _unitOfWork.Repository<Organization>().GetByIdAsync(organizationId);
            if (organizations == null) return NotFound();
            return Ok(organizations);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrganizationDto body)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _unitOfWork.Repository<Organization>().AddAsync(Mapper.Map<Organization>(body));
            await _unitOfWork.Commit();
            var a = DateTimeHelper.Now;
            return Ok(result.Id);
        }

        // PUT api/<controller>/<organizationId>
        [HttpPut]
        [Route("{organizationId}")]
        public async Task<IActionResult> Put(int organizationId, [FromBody] OrganizationDto body)
        {
            if (body == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var organization = await _unitOfWork.Repository<Organization>().GetByIdAsync(organizationId);

            if (organization == null)
                return NotFound();

            Mapper.Map(body, organization);
            _unitOfWork.Repository<Organization>().Update(organization);
            return Ok(organization);
        }

        // PATCH api/<controller>/<organizationId>
        [HttpPatch]
        [Route("{organizationId}")]
        public async Task<IActionResult> Patch(int organizationId, [FromBody] JsonPatchDocument<OrganizationDto> body)
        {
            if (body == null)
                return BadRequest();

            var organization = await _unitOfWork.Repository<Organization>().GetByIdAsync(organizationId);

            if (organization == null)
                return NotFound();

            var patchOrganization = Mapper.Map<OrganizationDto>(organization);
            body.ApplyTo(patchOrganization, ModelState);
            TryValidateModel(patchOrganization);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Mapper.Map(patchOrganization, organization);
            _unitOfWork.Repository<Organization>().Update(organization);
            return Ok(Mapper.Map<OrganizationDto>(organization));
        }

        // DELETE api/<controller>/<organizationId>
        [HttpDelete]
        [Route("{organizationId}")]
        public async Task<IActionResult> Delete(int organizationId)
        {
            var organization = await _unitOfWork.Repository<Organization>().GetByIdAsync(organizationId);

            if (organization == null)
                return NotFound();

            _unitOfWork.Repository<Organization>().Delete(organization);
            return NoContent();
        }
    }
}
