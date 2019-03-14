using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Persistence.Interfaces;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace CienciaArgentina.Microservices.Persistence.Redis
{
    public class Redis : ICache
    {
        internal readonly IDatabase _database;
        protected readonly IRedisConnectionFactory _connectionFactory;

        public Redis(IRedisConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _database = _connectionFactory.Connection().GetDatabase();
        }

        public async Task<bool> SaveAsync<T>(string key, T obj, TimeSpan? expiration = null, DateTime? until = null)
        {
            var jsonValue = JsonConvert.SerializeObject(obj);
            return await _database.StringSetAsync(key, jsonValue);
        }
        public async Task<T> GetAsync<T>(string key)
        {
            var value = await _database.StringGetAsync(key);
            var result = JsonConvert.DeserializeObject<T>(value);
            return result;
        }
        public async Task<bool> RemoveAsync(string key)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AddListAsync<T>(string key, T obj, TimeSpan? expiration = null, DateTime? until = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveListAsync<T>(string key, T obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<T>> GetListAsync<T>(string key)
        {
            throw new System.NotImplementedException();
        }
    }
}
