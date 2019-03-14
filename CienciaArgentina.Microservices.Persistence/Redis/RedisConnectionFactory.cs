using System;
using System.Collections.Generic;
using System.Text;
using CienciaArgentina.Microservices.Persistence.Interfaces;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace CienciaArgentina.Microservices.Persistence.Redis
{
    public class RedisConnectionFactory : IRedisConnectionFactory
    {
        private readonly Lazy<ConnectionMultiplexer> _connection;

        private readonly IOptions<RedisConfiguration> redis;

        public RedisConnectionFactory(IOptions<RedisConfiguration> redis)
        {
            var connectionMultiplexerOptions = new ConfigurationOptions
            {
                AbortOnConnectFail = false,

                Ssl = true,
                //ConnectRetry = 3,
                //ConnectTimeout = 5000,
                //SyncTimeout = 5000,
                //DefaultDatabase = Convert.ToInt32(redis.Value.DefaultDatabase),
                EndPoints = { { redis.Value.Host, redis.Value.Port } },
                Password = redis.Value.Password
            };
            this._connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(connectionMultiplexerOptions));
            //this._connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(redis.Value.Host));
        }

        public ConnectionMultiplexer Connection()
        {
            return this._connection.Value;
        }
    }
}