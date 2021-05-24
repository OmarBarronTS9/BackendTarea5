using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BACKEND_TAREA5.Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace BACKEND_TAREA5.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                AttachUserToContext(context, token);
            }
            await _next(context);
        }
        private void AttachUserToContext(HttpContext context, string token)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("axdertghyujkiolp"));
                var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    ValidAudience = "http://localhost:5001",
                    ValidIssuer = "http://localhost:5001",
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = this.LifeTimeValidator,
                    IssuerSigningKey = securityKey
                };
                tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var username = jwtToken.Claims.First(x => x.Type == "name").Value;
                context.Items["user"] = new UserSC().GetUserByUsername(username);
            }
            catch { }
        }

        public bool LifeTimeValidator(DateTime? notBefore, DateTime? expires,SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if(expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }
    }

    

}
