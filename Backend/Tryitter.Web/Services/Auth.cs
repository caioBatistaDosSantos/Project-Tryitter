using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using tryitter.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace TryitterAuth;
public class TokenGenerator
{
    public string Generate(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = AddClaims(user),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.ASCII
                    .GetBytes(
                        "fddtiryutg7ryutgyrtitytdsryirt")), 
                    SecurityAlgorithms.HmacSha256Signature),
            Expires = DateTime.Now.AddDays(1)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
    private ClaimsIdentity AddClaims(User user)
    {
        var claims = new ClaimsIdentity();

        claims.AddClaim(new Claim("Id", user.Id.ToString()));

        return claims;
    }
}