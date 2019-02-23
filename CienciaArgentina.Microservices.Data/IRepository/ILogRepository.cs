using System.Linq;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Entities.QueryParameters;
using CienciaArgentina.Microservices.Storage.Azure.TableStorage;

namespace CienciaArgentina.Microservices.Repositories.IRepository
{
    public interface ILogRepository
    {
        Task<IQueryable<AppExceptionData>> Get(QueryParameters userQueryParameters);

        Task<AppExceptionData> Get(string id);
    }
}