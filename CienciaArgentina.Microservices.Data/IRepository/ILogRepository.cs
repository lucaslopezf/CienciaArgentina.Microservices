using System.Linq;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Entities.Identity;
using CienciaArgentina.Microservices.Entities.Models;
using CienciaArgentina.Microservices.Entities.QueryParameters;
using CienciaArgentina.Microservices.Storage.Azure.TableStorage;
using Microsoft.AspNetCore.Identity;

namespace CienciaArgentina.Microservices.Data.IRepositories
{
    public interface ILogRepository
    {
        Task<IQueryable<AppExceptionData>> Get(QueryParameters userQueryParameters);

        Task<AppExceptionData> Get(string id);
    }
}