﻿using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Commons.Helpers.Date;
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

        public async Task<ApplicationUser> GetByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<ApplicationUser> Get(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user;
        }

        public async Task<IdentityResult> Add(ApplicationUser user,string password)
        {
            var result = await _userManager.CreateAsync(user,password);
            //TODO: Redis
            return result;
        }

        public async Task<IdentityResult> AddClaim(ApplicationUser user, Claim claim)
        {
            var result = await _userManager.AddClaimAsync(user, claim);
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
            user.DateDeleted = DateTimeHelper.Now;

            var result = await Update(user);
            return result;
        }

        public async Task<bool> IsEmailConfirmedAsync(ApplicationUser user)
        {
            //var user = await this.Get(userName);

            //if (user == null) return false;

            return await _userManager.IsEmailConfirmedAsync(user);
        }
        public async Task<bool> IsEmailConfirmedAsync(string userName)
        {
            var user = await this.Get(userName);

            if (user == null) return false;

            return await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            //var user = await this.Get(userName);

            //if (user == null) return string.Empty;

            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPassword(ApplicationUser user,string token,string password)
        {
            return await _userManager.ResetPasswordAsync(user, token, password);
        }

        public int Count()
        {
            return _context.Users.Count();
        }
    }
}
