using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Data.IRepositories;
using CienciaArgentina.Microservices.Entities.Identity;
using CienciaArgentina.Microservices.Entities.Models;
using CienciaArgentina.Microservices.Entities.QueryParameters;
using CienciaArgentina.Microservices.Storage.Azure.TableStorage.Queries;
using CienciaArgentina.Microservices.Storage.Azure;
using CienciaArgentina.Microservices.Storage.Azure.TableStorage;
using Microsoft.AspNetCore.Identity;

namespace CienciaArgentina.Microservices.Data.Repositories
{
    public class LogRepository : ILogRepository
    {
        private static readonly AppExceptionQuery _azureStorage = new AppExceptionQuery(AzureStorageAccount.DefaultAccount);

        public async Task<IQueryable<AppExceptionData>> Get(QueryParameters logQueryParameters)
        {
            IQueryable<AppExceptionData> listExceptions;

            if (!logQueryParameters.HasQuery)
                listExceptions = await _azureStorage.GetExceptions();
            else
                listExceptions = await _azureStorage.GetExceptions(logQueryParameters);

            if(logQueryParameters.Descending)
                return listExceptions.OrderByDescending(x => x.Date)
                    .Skip(logQueryParameters.PageCount * (logQueryParameters.Page - 1))
                    .Take(logQueryParameters.PageCount);

            return listExceptions.OrderBy(x => x.Date)
                .Skip(logQueryParameters.PageCount * (logQueryParameters.Page - 1))
                .Take(logQueryParameters.PageCount);
        }

        public async Task<AppExceptionData> Get(string id)
        {
            var exception = await _azureStorage.GetExceptions(id);
            return exception;
        }
    }
}
