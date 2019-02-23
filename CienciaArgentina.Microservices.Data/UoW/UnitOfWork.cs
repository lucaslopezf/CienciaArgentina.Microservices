using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Data.IRepositories;
using CienciaArgentina.Microservices.Entities.Identity;
using CienciaArgentina.Microservices.Entities.Models;
using CienciaArgentina.Microservices.Persistence;
using CienciaArgentina.Microservices.Repositories.IRepository;
using CienciaArgentina.Microservices.Repositories.IUoW;
using CienciaArgentina.Microservices.Repositories.Repository;
using Microsoft.AspNetCore.Identity;

namespace CienciaArgentina.Microservices.Repositories.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CienciaArgentinaDbContext _dbContext;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        public ILogRepository LogRepository { get; }

        public Dictionary<Type, object> Repositories
        {
            get { return _repositories; }
            set { Repositories = value; }
        }

        public UnitOfWork(CienciaArgentinaDbContext dbContext)
        {
            _dbContext = dbContext;
            LogRepository = new LogRepository();
        }

        public IGenericRepository<T> Repository<T>() where T : BaseModel
        {
            if (Repositories.Keys.Contains(typeof(T)))
            {
                return Repositories[typeof(T)] as IGenericRepository<T>;
            }

            IGenericRepository<T> repo = new GenericRepository<T>(_dbContext);
            Repositories.Add(typeof(T), repo);
            return repo;
        }

        public async Task<int> Commit()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Rollback()
        {
            _dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
    }
}
