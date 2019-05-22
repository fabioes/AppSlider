using System.Linq;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AppSlider.WebApi.Filters
{
    public class SwaggerAuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation?.Tags?.Any(a => (a ?? "").ToLower() == "login") == true) return;

            operation.Parameters?.Add(new BodyParameter
            {
                Name = "Authorization",
                In = "header",
                Description = "Token 'Bearer' obrigatório retornado na rota de login.",
                Required = true
            });
        }
    }
}