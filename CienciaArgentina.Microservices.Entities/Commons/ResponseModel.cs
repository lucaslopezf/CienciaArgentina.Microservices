using System.Collections.Generic;
using CienciaArgentina.Microservices.Entities.BusinessModel;

namespace CienciaArgentina.Microservices.Entities.Commons
{
    public class ResponseModel<T>
    {
        public ResponseModel(bool value = false)
        {
            Success = value;
        }

        public ResponseModel(T data,bool value = false)
        {
            Success = value;
            Data = data;
        }

        public void AddError(ErrorResponseModel error)
        {
            Error.Add(error);
        }

        public bool Success { get; set; }

        public List<ErrorResponseModel> Error { get; set; } = new List<ErrorResponseModel>();
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
