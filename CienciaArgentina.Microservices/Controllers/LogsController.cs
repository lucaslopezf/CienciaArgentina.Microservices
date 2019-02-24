using System;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AutoMapper;
using CienciaArgentina.Microservices.Commons.Extensions;
using CienciaArgentina.Microservices.Data;
using CienciaArgentina.Microservices.Dtos;
using CienciaArgentina.Microservices.Storage.Azure;
using CienciaArgentina.Microservices.Storage.Azure.TableStorage.Queries;
using Microsoft.AspNetCore.Mvc;
using CienciaArgentina.Microservices.Entities.QueryParameters;
using CienciaArgentina.Microservices.Repositories.IRepository;
using CienciaArgentina.Microservices.Storage.Azure.QueueStorage.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CienciaArgentina.Microservices.Controllers
{
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly ILogRepository _logRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogsController(IHttpContextAccessor httpContextAccessor,ILogRepository logRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _logRepository = logRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(QueryParameters queryParameters)
        {
            var result = await _logRepository.Get(queryParameters);

            if (result == null) return NotFound();

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(new { totalCount = result.Count() }));

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}", Name ="Get")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _logRepository.Get(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]LogDto logDto)
        {
            if (logDto == null)
                return BadRequest("exceptionDto object is null");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exception = new Exception(logDto.Message);

            var guid = Guid.NewGuid();
            exception.Log(_httpContextAccessor.HttpContext,guid,logDto.Detail,logDto.Source,logDto.CustomMessage);

            return CreatedAtRoute("Get", new { id = guid }, logDto);
        }
    }
}