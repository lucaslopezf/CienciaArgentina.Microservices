using System;
using System.Collections.Generic;
using System.Text;
using CienciaArgentina.Microservices.Entities.Models;
using CienciaArgentina.Microservices.Persistence;
using CienciaArgentina.Microservices.Repositories.Repository;
using CienciaArgentina.Microservices.Repositories.UoW;

namespace CienciaArgentina.UnitTests.TestFixtures
{
    public class CommonFixture<T> where T : BaseModel
    {
        public CienciaArgentinaDbContext Context { get; }
        public GenericRepository<T> GenericRepository { get; }
        public AccountRepository AccountRepository { get; }
        public UnitOfWork UnitOfWork { get; }

        public CommonFixture()
        {
            
            //Context = new CienciaArgentinaDbContext(options => options.UseSqlServer(ConfigurationManager.));
        }
    }
}
