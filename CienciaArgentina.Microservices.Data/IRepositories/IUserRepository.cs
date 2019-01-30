using System;
using System.Linq;
using CienciaArgentina.Microservices.Entities.Models;
using CienciaArgentina.Microservices.Entities.QueryParameters;

namespace CienciaArgentina.Microservices.Data.IRepositories
{
    public interface IUserRepository
    {
        IQueryable<User> Get(QueryParameters userQueryParameters);
        User Get(int id);
        void Add(User item);
        void Delete(int id);
        void Update(User item);
        int Count();
        bool Save();
    }
}