using System;
using System.Linq;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Data.IRepositories;
using CienciaArgentina.Microservices.Entities.Models.User;
using CienciaArgentina.Microservices.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CienciaArgentina.Microservices.Repositories.Repository
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
