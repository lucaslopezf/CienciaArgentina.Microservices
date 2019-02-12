using System.Threading.Tasks;
using CienciaArgentina.Microservices.Data;
using CienciaArgentina.Microservices.Data.IRepositories;
using CienciaArgentina.Microservices.Storage.Azure;
using CienciaArgentina.Microservices.Storage.Azure.TableStorage.Queries;
using Microsoft.AspNetCore.Mvc;
using CienciaArgentina.Microservices.Entities.QueryParameters;
using Newtonsoft.Json;

namespace CienciaArgentina.Microservices.Controllers
{
    [Route("api/[controller]")]
    public class LogController : ControllerBase
    {
        private readonly ILogRepository _logRepository;

        public LogController(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(QueryParameters queryParameters)
        {
            var result = await _logRepository.Get(queryParameters);

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(new { totalCount = _logRepository.Count() }));

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _logRepository.Get(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}