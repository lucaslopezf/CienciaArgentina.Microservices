using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Entities.BusinessModel
{
    public class ResponseModel
    {
        public ResponseModel(bool value)
        {
            Success = value;
        }

        public void AddError(ErrorResponseModel error)
        {
            Errors.Add(error);
        }
        public bool Success { get; set; }

        public List<ErrorResponseModel> Errors { get; } = new List<ErrorResponseModel>();
        public string Message { get; set; }
    }
}
