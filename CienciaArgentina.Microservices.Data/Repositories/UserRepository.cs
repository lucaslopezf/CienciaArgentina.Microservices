using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CienciaArgentina.Microservices.Data.IRepositories;
using CienciaArgentina.Microservices.Entities.Models;
using CienciaArgentina.Microservices.Entities.QueryParameters;
using System.Linq.Dynamic.Core;

namespace CienciaArgentina.Microservices.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CienciaArgentinaDbContext _context;

        public UserRepository(CienciaArgentinaDbContext context)
        {
            _context = context;
        }

        public IQueryable<User> Get(QueryParameters userQueryParameters)
        {
            IQueryable<User> allUsers = _context.Users.OrderBy(userQueryParameters.OrderBy,
                userQueryParameters.Descending);

            if (userQueryParameters.HasQuery)
            {
                allUsers = allUsers
                    .Where(x => x.Username.ToLowerInvariant().Contains(userQueryParameters.Query.ToLowerInvariant()));
                //|| x.LastName.ToLowerInvariant().Contains(userQueryParameters.Query.ToLowerInvariant()));
            }

            return allUsers.OrderBy(x => x.Username)
                .Skip(userQueryParameters.PageCount * (userQueryParameters.Page - 1))
                .Take(userQueryParameters.PageCount);
        }

        public IQueryable<User> Get()
        {
            return _context.Users.Select(x => x);
        }

        public User Get(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Add(User item)
        {
            _context.Users.Add(item);
        }

        public void Delete(int id)
        {
            User user = Get(id);
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
