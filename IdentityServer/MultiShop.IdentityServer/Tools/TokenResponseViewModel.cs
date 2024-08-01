using System;

namespace MultiShop.IdentityServer.Tools
{
	public class TokenResponseViewModel
	{
		public TokenResponseViewModel(string token, DateTime expireDate)
		{
			Token = token;
			ExpiredDate = expireDate;
		}
		public string Token { get; set; }
		public DateTime ExpiredDate { get; set; }
	}
}
