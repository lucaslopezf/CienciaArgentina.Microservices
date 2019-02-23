using System.Linq;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Entities.Identity;
using CienciaArgentina.Microservices.Entities.QueryParameters;
using Microsoft.AspNetCore.Identity;

namespace CienciaArgentina.Microservices.Repositories.IRepository
{
    public interface IAccountRepository
    {
        IQueryable<ApplicationUser> Get(QueryParameters userQueryParameters);

        Task<ApplicationUser> Get(string id);

        Task<IdentityResult> Add(ApplicationUser user, string password);

        Task<IdentityResult> Update(ApplicationUser user);

        Task<IdentityResult> Delete(ApplicationUser user);

        int Count();
    }
}