using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MultiShop.IdentityServer.Tools
{
	public class JwtTokenGenerator
	{
		public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel getCheckAppUserViewModel)
		{
			var claims = new List<Claim>();
			if (!string.IsNullOrWhiteSpace(getCheckAppUserViewModel.Role))
				claims.Add(new Claim(ClaimTypes.Role, getCheckAppUserViewModel.Role));

			claims.Add
				(new Claim(ClaimTypes.NameIdentifier, getCheckAppUserViewModel.Id));

			if (!string.IsNullOrWhiteSpace(getCheckAppUserViewModel.UserName))
				claims.Add(new Claim("Username", getCheckAppUserViewModel.UserName));

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefault.Secret));

			var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var expireDate = DateTime.UtcNow.AddMinutes(JwtTokenDefault.ExpireInMinutes);

			JwtSecurityToken token = new JwtSecurityToken(
				issuer: JwtTokenDefault.ValidIssuer,
				audience: JwtTokenDefault.ValidAudience,
				claims: claims,
				expires: expireDate,
				signingCredentials: signingCredentials
			);
			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			var tokenString = tokenHandler.WriteToken(token);
			return new TokenResponseViewModel(tokenString, expireDate);
		}
	}
}
