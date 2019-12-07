using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Entities.Identity;
using CienciaArgentina.Microservices.Entities.QueryParameters;
using Microsoft.AspNetCore.Identity;

namespace CienciaArgentina.Microservices.Repositories.IRepository
{
    public interface IAccountRepository
    {
        IQueryable<ApplicationUser> Get(QueryParameters userQueryParameters);

        Task<ApplicationUser> Get(string userName);

        Task<ApplicationUser> GetByEmail(string email);

        Task<IdentityResult> Add(ApplicationUser user, string password);

        Task<IdentityResult> AddClaim(ApplicationUser user, Claim claim);

        Task<IdentityResult> Update(ApplicationUser user);

        Task<IdentityResult> Delete(ApplicationUser user);

        Task<bool> IsEmailConfirmedAsync(ApplicationUser user);

        Task<bool> IsEmailConfirmedAsync(string userName);

        Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
        int Count();
    }
}