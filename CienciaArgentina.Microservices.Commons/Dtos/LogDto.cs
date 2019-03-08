using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Commons.Dtos
{
    public class LogDto
    {
        public string Message { get; set; }
        public string Detail { get; set; }
        public string CustomMessage { get; set; }
        public string Source { get; set; }
    }
}
