using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Entities.Identity;
using CienciaArgentina.Microservices.Entities.QueryParameters;
using CienciaArgentina.Microservices.Persistence;
using CienciaArgentina.Microservices.Repositories.IRepository;
using Microsoft.AspNetCore.Identity;

namespace CienciaArgentina.Microservices.Repositories.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CienciaArgentinaDbContext _context;

        public AccountRepository(CienciaArgentinaDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IQueryable<ApplicationUser> Get(QueryParameters userQueryParameters)
        {
            
            IQueryable<ApplicationUser> allUsers;
            if (!userQueryParameters.HasQuery)
                allUsers = _context.Users.OrderBy(userQueryParameters.OrderBy,userQueryParameters.Descending);
            else
                allUsers = _context.Users
                    .Where(x => x.UserName.ToLowerInvariant().Contains(userQueryParameters.Query.ToLowerInvariant()))
                    .OrderBy(userQueryParameters.OrderBy, userQueryParameters.Descending);

            return allUsers.OrderBy(x => x.UserName)
                .Skip(userQueryParameters.PageCount * (userQueryParameters.Page - 1))
                .Take(userQueryParameters.PageCount);
        }

        public async Task<ApplicationUser> Get(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<IdentityResult> Add(ApplicationUser user,string password)
        {
            var result = await _userManager.CreateAsync(user,password);
            //TODO: Redis
            return result;
        }

        public async Task<IdentityResult> Update(ApplicationUser user)
        {
            var result = await _userManager.UpdateAsync(user);
            return result;
        }

        public async Task<IdentityResult> Delete(ApplicationUser user)
        {
            user.DateDeleted = DateTime.Now;

            var result = await Update(user);
            return result;
        }

        public int Count()
        {
            return _context.Users.Count();
        }
    }
}
