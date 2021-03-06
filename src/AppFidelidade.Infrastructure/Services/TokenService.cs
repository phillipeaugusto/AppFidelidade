using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AppFidelidade.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace AppFidelidade.Infrastructure.Services;

public static class TokenService
{
    public static string GenerateToken(Client client)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Sid, client.Id.ToString()),
                new Claim(ClaimTypes.Role, client.Role)
            }),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(SettingsToken.Key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}