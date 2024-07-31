using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using MultiShop.IdentityServer.Tools;

namespace MultiShop.IdentityServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginsController : ControllerBase
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _userManager;
		public LoginsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}
		[HttpPost]
		public async Task<IActionResult> Login(UserLoginDto userLoginDto)
		{
			var result =
				await _signInManager.PasswordSignInAsync(userLoginDto.UserName, userLoginDto.Password, false, false);

			var user = await _userManager.FindByNameAsync(userLoginDto.UserName);

			if (result.Succeeded)
			{
				GetCheckAppUserViewModel getCheckAppUserViewModel = new GetCheckAppUserViewModel
				{
					Id = user.Id,
					UserName = userLoginDto.UserName,
					Role = "User",
					IsExist = true
				};
				var token = JwtTokenGenerator.GenerateToken(getCheckAppUserViewModel);
				return Ok(token);
			}
			return Ok("Kullanıcı adı veya şifre hatalı");
		}
	}
}
