using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using AutoMapper.Configuration;
using CienciaArgentina.Microservices.Commons.Helpers;
using CienciaArgentina.Microservices.Commons.Dtos;
using CienciaArgentina.Microservices.Entities.Identity;
using CienciaArgentina.Microservices.Entities.Models;
using CienciaArgentina.Microservices.Entities.Models.User;
using CienciaArgentina.Microservices.Entities.QueryParameters;
using CienciaArgentina.Microservices.Repositories.IRepository;
using CienciaArgentina.Microservices.Repositories.IUoW;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using Newtonsoft.Json;

namespace CienciaArgentina.Microservices.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        //TODO: Repositories? 

        //GET api/<controller>
        [HttpGet]
        public IActionResult Get(QueryParameters rolQueryParameters)
        {
            //TODO: Finish this microservices
            var allRoles = _roleManager.Roles;

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(new { totalCount = allRoles.Count() }));

            return Ok(allRoles);
        }

        //GET api/<controller>/roleName
        [HttpGet]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(int), 404)]
        [Route("{roleName}")]
        public async Task<IActionResult> Get(string roleName)
        {
            var result = await _roleManager.FindByNameAsync(roleName);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string roleName)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
            if (result.Errors.Count() > 0)
                return BadRequest(result.Errors);

            return Ok(result.Succeeded);
        }

        // POST api/<controller>
        [HttpPost]
        [Route("{roleClaim}")]
        public async Task<IActionResult> AddClaim([FromBody] CreateClaimDto roleClaim)
        {
            var role = await _roleManager.FindByNameAsync(roleClaim.TypeName);
            var claim = new Claim(roleClaim.ClaimType, roleClaim.ClaimValue);
            var result = await _roleManager.AddClaimAsync(role, claim);
            if (result.Errors.Count() > 0)
                return BadRequest(result.Errors);

            return Ok(result.Succeeded);
        }
    }
}
