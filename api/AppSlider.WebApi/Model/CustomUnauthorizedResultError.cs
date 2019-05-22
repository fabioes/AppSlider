using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppSlider.WebApi.Model
{
    public class CustomUnauthorizedResultError : JsonResult
    {
        public CustomUnauthorizedResultError(string message)
            : base(new ApiReturnItem<object>
            {
                Item = null,
                ApiReturnMessage = new ApiReturnMessage
                {
                    Title = message
                },
                Success = false
            })
        {
            StatusCode = StatusCodes.Status401Unauthorized;
        }
    }
}