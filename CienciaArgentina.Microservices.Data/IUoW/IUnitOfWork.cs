using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Entities.Models;
using CienciaArgentina.Microservices.Repositories.IRepository;

namespace CienciaArgentina.Microservices.Repositories.IUoW
{
    public interface IUnitOfWork
    {
        //Repositories
        IGenericRepository<T> Repository<T>();

        ILogRepository LogRepository { get; }

        //
        Task<int> Commit();

        void Rollback();
    }
}
