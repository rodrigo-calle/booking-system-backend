using IdentityServer4.Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.IS
{

    /// <summary>
    /// 
    /// </summary>
    public class TokenValidateService : ICustomTokenRequestValidator
    {

        private readonly HttpContext _httpContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextAccessor"></param>
        public TokenValidateService(IHttpContextAccessor contextAccessor)
        {
            _httpContext = contextAccessor.HttpContext;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task ValidateAsync(CustomTokenRequestValidationContext context)
        {
            var numero_documento = context.Result.ValidatedRequest.Raw.Get("client_numero_documento");
            var codigo_usuario = context.Result.ValidatedRequest.Raw.Get("client_codigo_usuario");
            context.Result.ValidatedRequest.Client.AlwaysSendClientClaims = true;
            context.Result.ValidatedRequest.ClientClaims.Add(new Claim("numero_documento", numero_documento));
            context.Result.ValidatedRequest.ClientClaims.Add(new Claim("codigo_usuario", codigo_usuario));
            return Task.FromResult(0);
        }
    }
}
