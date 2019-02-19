using System;

namespace CienciaArgentina.Microservices.Data.IRepositories
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }
}