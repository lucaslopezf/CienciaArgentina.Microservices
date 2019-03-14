using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;

namespace CienciaArgentina.Microservices.Persistence.Interfaces
{
    public interface IRedisConnectionFactory
    {
        ConnectionMultiplexer Connection();
    }
}
