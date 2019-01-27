using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CienciaArgentina.Microservices.Data.IRepositories;
using CienciaArgentina.Microservices.Entities.Models;

namespace CienciaArgentina.Microservices.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CienciaArgentinaDbContext _context;

        public UserRepository(CienciaArgentinaDbContext context)
        {
            _context = context;
        }

        //TODO GetAll with pagination
        public IQueryable<User> GetAll()
        {
            return _context.Users.Select(x => x);
        }

        public User GetSingle(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Add(User item)
        {
            _context.Users.Add(item);
        }

        public void Delete(int id)
        {
            User user = GetSingle(id);
            _context.Users.Remove(user);
        }

        public void Update(User item)
        {
            _context.Users.Update(item);
        }

        public int Count()
        {
            return _context.Users.Count();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
