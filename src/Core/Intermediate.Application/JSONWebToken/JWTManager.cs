using Intermediate.Application.Features.AuthenticationOperations;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Intermediate.Application.JSONWebToken;

public class JWTManager : IJWTManager
{
     public string GenerateJSONWebToken(LoginCommandResponse userInfo)
     {
          var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTModel.Key));
          var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

          var claims = new[]
          {
                new Claim(ClaimTypes.NameIdentifier, userInfo.Id.ToString()),
                //new Claim(ClaimTypes.Email,userInfo.Email),
                new Claim(ClaimTypes.Name,userInfo.UserName),
                new Claim(ClaimTypes.Role, "Admin"),
                //new Claim(JwtRegisteredClaimNames.Sub,userInfo.FirstName),
                //new Claim(JwtRegisteredClaimNames.Sub,userInfo.LastName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
          };

          JwtSecurityToken token = new(
               claims: claims,
               issuer: JWTModel.Issuer,
               audience: JWTModel.Audience,
               expires: DateTime.Now.AddMinutes(30),
               signingCredentials: creds);

          return new JwtSecurityTokenHandler().WriteToken(token);
     }
}
