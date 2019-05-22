using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AppSlider.Domain;
using AppSlider.Domain.Authentication;
using AppSlider.Utils.Cripto;
using AppSlider.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

namespace AppSlider.WebApi.Filters
{
    public class CustomAuthorizeFilter : IAsyncAuthorizationFilter
    {
        private LoggedUser _loggedUser { get; set; }
        public AuthorizationPolicy Policy { get; }

        public CustomAuthorizeFilter([FromServices] LoggedUser loggedUser, AuthorizationPolicy policy)
        {
            _loggedUser = loggedUser;
            Policy = policy ?? throw new ArgumentNullException(nameof(policy));
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            // Allow Anonymous skips all authorization
            if (context.Filters.Any(item => item is IAllowAnonymousFilter))
            {
                return;
            }
            
            var policyEvaluator = context.HttpContext.RequestServices.GetRequiredService<IPolicyEvaluator>();
            var authenticateResult = await policyEvaluator.AuthenticateAsync(Policy, context.HttpContext);
            var authorizeResult =
                await policyEvaluator.AuthorizeAsync(Policy, authenticateResult, context.HttpContext, context);

            if (authorizeResult.Challenged)
            {
                // Return custom 401 result
                context.Result = new CustomUnauthorizedResultError("Permissão Negada!");
            }
            else if (authorizeResult.Forbidden)
            {
                // Return default 403 result
                context.Result = new ForbidResult(Policy.AuthenticationSchemes.ToArray());
            }
            else
            {
                try
                {
                    context.HttpContext.Request.Headers.TryGetValue("Authorization",
                        out StringValues authorization);
                    var token =
                        authorization.ToString().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                    var handler = new JwtSecurityTokenHandler();
                    var decodedToken = handler.ReadToken(token) as JwtSecurityToken;
                    var userToken = decodedToken.Claims.First(claim => claim.Type == "unique_name").Value;
                    var activeUserToken = decodedToken.Claims.First(claim => claim.Type == "unac").Value == "true";
                    _loggedUser.User = userToken;

                    if (!activeUserToken)
                        context.Result = new CustomUnauthorizedResultError($"Permissão Negada! - Usuário: {userToken} está inativo!");


                    if (!ValidateUserRoutePermission(decodedToken, context.HttpContext))
                    {
                        // Return custom 401 result
                        context.Result = new CustomUnauthorizedResultError("Permissão Negada - Rota liberada apenas para Administradores.");
                    }
                }
                catch (Exception ex)
                {
                    throw new BusinessException(
                        "Erro ao validar token / usuário!. Favor realizar o Login novamente!", ex,
                        "CustomAuthorizeFilter - SetLoggedUser");
                }
            }
        }

        private bool ValidateUserRoutePermission(JwtSecurityToken token, HttpContext httpContext)
        {
            var adminRoutes = new List<String>
            {
                "users",
                "logs"
            };

            var profile = token.Payload["unpr"].ToString();

            if (String.IsNullOrWhiteSpace(profile)) return false;

            var decodeProfile = CriptoManager.Base64Decode(profile);

            if (decodeProfile != "admin" && adminRoutes.Contains((httpContext.Request.Path.Value ?? "").ToLower())) return false;

            return true;
        }
    }
}