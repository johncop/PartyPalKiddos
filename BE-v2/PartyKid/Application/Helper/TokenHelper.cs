using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace PartyKid;

public static class TokenHelper
{
    public static string GenerateToken(ApplicationUser user, IList<string> roles, string secret)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        byte[] key = Encoding.ASCII.GetBytes(secret);
        List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Id.ToString()),
            };
        //claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        foreach (var userRole in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, userRole));
        }

        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = "PartyKid",
            //Audience = user.Id,
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        string tokenString = tokenHandler.WriteToken(token);
        return tokenString;
    }
}
