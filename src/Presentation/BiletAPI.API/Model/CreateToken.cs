using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BiletAPI.API.Model
{
	public class CreateToken
	{
		public string TokenCreate()
		{
			var bytes= Encoding.UTF8.GetBytes("salkdaskdsakldsladksladlksadkasdlkasdsakldklasaslk");
			SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);
			SigningCredentials credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
			List<Claim> claims = new List<Claim>()
			{
				new Claim(ClaimTypes.NameIdentifier,Guid.NewGuid().ToString()),
				new Claim(ClaimTypes.Name,"UserName"),//farklı kullanıcılara göre token üretir
				new Claim(ClaimTypes.Surname,"UserSurname")//farklı kullanıcılara göre token üretir
			};

			JwtSecurityToken token = new JwtSecurityToken(issuer: "http//localhost", audience: "http//localhost", notBefore: DateTime.Now, expires: DateTime.Now.AddHours(10), signingCredentials: credentials,claims:claims);
			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
			return handler.WriteToken(token);
		}
	}
}
