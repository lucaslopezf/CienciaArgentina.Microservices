using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Entities.Dtos;
using CienciaArgentina.Microservices.Entities.Models;
using CienciaArgentina.Microservices.Entities.QueryParameters;

namespace CienciaArgentina.Microservices.Data.IRepositories
{
    public interface IUserDataRepository
    {
        Task<UserData> Get(Guid userId);

        Task<int> Add(UserData userData);

        void Update(UserData user);

        void Delete(UserData user);

        Task Save();

        int Count();
    }
}
