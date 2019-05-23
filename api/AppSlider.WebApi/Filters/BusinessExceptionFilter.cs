namespace AppSlider.WebApi.Filters
{
    using AppSlider.Domain;
    using AppSlider.WebApi.Model;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    public class BusinessExceptionFilter : IExceptionFilter
    {
        
        public void OnException(ExceptionContext context)
        {
        
            if (context.Exception is AggregateException aggregateException && aggregateException.InnerException is BusinessException apiGlobalInnerException)
            {
                HandlingBusinessExceptionApi(context, apiGlobalInnerException);

            }
            else if (context.Exception is BusinessException BusinessException)
            {
                HandlingBusinessExceptionApi(context, BusinessException);
            }
            else
            {
                var objJsonRetorno = new ApiReturnItem<object>
                {
                    Item = null,
                    Success = false,
                    ApiReturnMessage = new ApiReturnMessage
                    {
                        Title = "Erro ao executar a Requisição!",
                        Details = new List<string> { context.Exception.Message }
                    }
                };

                HandlingInnerExceptions(context, objJsonRetorno);

                context.Result = new BadRequestObjectResult(objJsonRetorno);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }

        private static void HandlingBusinessExceptionApi(ExceptionContext context,
            BusinessException BusinessException)
        {

            var objJsonRetorno = new ApiReturnItem<object>
            {
                Item = null,
                Success = false,
                ApiReturnMessage = new ApiReturnMessage
                {
                    Title = String.IsNullOrWhiteSpace(BusinessException.Message) ? "Erro ao executar a Requisição!" : BusinessException.Message,
                    Details = BusinessException.Messages?.Any() == true ? BusinessException.Messages : new List<String> { BusinessException.Message }
                }
            };

            HandlingInnerExceptions(context, objJsonRetorno);

            var titleOfExistingException = objJsonRetorno.ApiReturnMessage?.Title;

            if (!String.IsNullOrWhiteSpace(titleOfExistingException))
            {
                if (objJsonRetorno.ApiReturnMessage.Details.Contains(titleOfExistingException))
                    objJsonRetorno.ApiReturnMessage.Details.Remove(titleOfExistingException);
            }

            context.Result = new BadRequestObjectResult(objJsonRetorno);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
        }

        private static void HandlingInnerExceptions(ExceptionContext context, ApiReturnItem<object> objJsonRetorno)
        {
            if (context.Exception.InnerException != null)
            {
                var excpt = context.Exception.InnerException;
                var countExcpt = 0;

                while (excpt != null && countExcpt < 5)
                {
                    if (!objJsonRetorno.ApiReturnMessage.Details.Contains(excpt.Message))
                        objJsonRetorno.ApiReturnMessage.Details.Add(excpt.Message);

                    excpt = excpt.InnerException;
                }
            }
        }
    }
}
