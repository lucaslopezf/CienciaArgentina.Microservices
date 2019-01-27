using System;
using System.Linq;
using CienciaArgentina.Microservices.Entities.Models;

namespace CienciaArgentina.Microservices.Data.IRepositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        User GetSingle(int id);
        void Add(User item);
        void Delete(int id);
        void Update(User item);
        int Count();
        bool Save();
    }
}