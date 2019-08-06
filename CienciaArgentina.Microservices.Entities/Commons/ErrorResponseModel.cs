using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.BusinessModel
{
    public class ErrorResponseModel
    {
        public ErrorResponseModel(string code, string detail)
        {
            Code = code;
            Detail = detail;
        }

        public ErrorResponseModel(){}

        public string Code { get; set; }
        public string Detail { get; set; }
    }
}
