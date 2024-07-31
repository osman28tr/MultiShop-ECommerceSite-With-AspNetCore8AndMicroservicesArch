namespace MultiShop.IdentityServer.Tools
{
	public class JwtTokenDefault
	{
		public const string ValidAudience = "https://localhost:5001";
		public const string ValidIssuer = "https://localhost:5001";
		public const string Secret = "Multishop.0102030405Asp.NetCore8.0*/+-";
		public const int ExpireInMinutes = 60;
	}
}
