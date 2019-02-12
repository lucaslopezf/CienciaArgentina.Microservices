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
    public class ExceptionController : ControllerBase
    {
        private readonly IExceptionRepository _exceptionRepository;

        public ExceptionController(IExceptionRepository exceptionRepository)
        {
            _exceptionRepository = exceptionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(QueryParameters queryParameters)
        {
            var result = await _exceptionRepository.Get(queryParameters);

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(new { totalCount = _exceptionRepository.Count() }));

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _exceptionRepository.Get(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}