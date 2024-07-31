using System.Security.Claims;
using MultiShop.MvcUI.Services.Abstract;

namespace MultiShop.MvcUI.Services
{
	public class LoginService : ILoginService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		public LoginService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}
		private string getUserId;
		public string GetUserId
		{
			get { return getUserId; }
			set { getUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value; }
		}
	}
}
