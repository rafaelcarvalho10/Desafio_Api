using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Desafio.Api.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Desafio.Api.Service.Jwt
{
  public static class TokenService
  {
    //   public static string GenerateToken(Usuario usuario)
    //   {
    //     var tokenHandler = new JwtSecurityTokenHandler();
    //     var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET"));
    //     var tokenDescriptor = new SecurityTokenDescriptor
    //     {
    //       Subject = new ClaimsIdentity(new Claim[]
    //         {
    //                   new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
    //                   new Claim(ClaimTypes.Email, usuario.Email.ToString()),
    //         }),
    //       Expires = DateTime.UtcNow.AddDays(24),
    //       SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    //     };
    //     var token = tokenHandler.CreateToken(tokenDescriptor);
    //     return tokenHandler.WriteToken(token);
    //   }
  }
}