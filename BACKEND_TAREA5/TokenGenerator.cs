using System;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BACKEND_TAREA5
{
    public static class TokenGenerator
    {
        public static string GenerateTokenJWT(String Username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("axdertghyujkiolp"));
            var signingCredential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            ClaimsIdentity claims = new ClaimsIdentity(new[] { new Claim("name", Username) });
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: "http://localhost:5001",
                issuer: "http://localhost:5001",
                subject: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: signingCredential
                );
            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }
    }
}
