using CienciaArgentina.Microservices.Entities.BusinessModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace CienciaArgentina.Microservices.Commons.Extensions
{
    public static class ModelStateExtensions
    {
        public static ModelStateDictionary AddErrorsToModelState(this ModelStateDictionary modelState, List<ErrorResponseModel> errors)
        {
            foreach (var error in errors)
            {
                modelState.AddModelError(error.Code, error.Detail);
            }

            return modelState;
        }

        public static ModelStateDictionary AddErrorsToModelState(this ModelStateDictionary modelState, List<IdentityError> errors)
        {
            foreach (var error in errors)
            {
                modelState.AddModelError(error.Code, error.Description);
            }

            return modelState;
        }
    }
}
