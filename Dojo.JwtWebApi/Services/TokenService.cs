// Dojo/Dojo.JwtWebApi/TokenService.cs/03/07/2021

#region USINGS

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Dojo.JwtWebApi.Domain.Dto;
using Dojo.JwtWebApi.Domain.Settings;

using Microsoft.IdentityModel.Tokens;

#endregion

namespace Dojo.JwtWebApi.Services
{
	public static class TokenService
	{
		public static string GenerateToken(User user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(Settings.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.Name, user.Username.ToString()),
					new Claim(ClaimTypes.Role, user.Role.ToString())
				}),
				Expires = DateTime.UtcNow.AddHours(2),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
				EncryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Yiozei9cwEZbEAdA")),SecurityAlgorithms.Aes256CbcHmacSha512, SecurityAlgorithms.Aes128CbcHmacSha256)
			};
			var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
