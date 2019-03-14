using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CienciaArgentina.Microservices.Persistence.Interfaces
{
    public interface ICache
    {
        Task<bool> SaveAsync<T>(string key, T obj, TimeSpan? expiration = null, DateTime? until = null);
        Task<T> GetAsync<T>(string key);
        Task<bool> RemoveAsync(string key);

        Task<bool> AddListAsync<T>(string key, T obj, TimeSpan? expiration = null, DateTime? until = null);
        Task<bool> RemoveListAsync<T>(string key, T obj);
        Task<List<T>> GetListAsync<T>(string key);
    }
}
