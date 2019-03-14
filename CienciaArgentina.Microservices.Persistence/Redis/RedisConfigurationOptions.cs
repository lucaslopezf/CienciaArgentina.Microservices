using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Persistence.Redis
{
    //Documentation: https://stackexchange.github.io/StackExchange.Redis/Configuration
    public class RedisConfiguration
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Name { get; set; }
        public string DefaultDatabase { get; set; }

        public string Password { get; set; }
    }
}
