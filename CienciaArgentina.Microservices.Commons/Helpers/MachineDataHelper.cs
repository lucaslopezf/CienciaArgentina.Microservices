using System;
using System.Collections.Generic;
using System.Text;
using CienciaArgentina.Microservices.Data.IRepositories;

namespace CienciaArgentina.Microservices.Commons.Helpers
{
    public class MachineDataHelper : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}
