using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CienciaArgentina.Microservices.Data.IRepositories;
using CienciaArgentina.Microservices;
using CienciaArgentina.Microservices.Entities.Models;
using CienciaArgentina.Microservices.Entities.QueryParameters;
using Microsoft.EntityFrameworkCore;

namespace CienciaArgentina.Microservices.Data.Repositories
{
    public class UserDataRepository : IUserDataRepository
    {
        private readonly CienciaArgentinaDbContext _context;

        public UserDataRepository(CienciaArgentinaDbContext context)
        {
            _context = context;
        }

        public async Task<UserData> Get(Guid userId)
        {
            var userData = await _context.UsersData.FirstOrDefaultAsync(x => x.UserId == userId);
            return userData;
        }

        public async Task<int> Add(UserData userData)
        {
            userData.DateCreated = DateTime.Now;
            var result = await _context.UsersData.AddAsync(userData);
            return result.Entity.Id;
        }

        public void Update(UserData userData)
        {
            _context.UsersData.Update(userData);
        }

        public void Delete(UserData userData)
        {
            userData.DateDeleted = DateTime.Now;
            _context.UsersData.Update(userData);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public int Count()
        {
            return _context.UsersData.Count();
        }
    }
}
