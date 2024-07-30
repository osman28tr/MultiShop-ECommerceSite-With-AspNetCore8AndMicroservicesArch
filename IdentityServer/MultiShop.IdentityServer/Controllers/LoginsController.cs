﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;

namespace MultiShop.IdentityServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginsController : ControllerBase
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		public LoginsController(SignInManager<ApplicationUser> signInManager)
		{
			_signInManager = signInManager;
		}
		[HttpPost]
		public async Task<IActionResult> Login(UserLoginDto userLoginDto)
		{
			var result =
				await _signInManager.PasswordSignInAsync(userLoginDto.UserName, userLoginDto.Password, false, false);
			if (result.Succeeded)
			{
				return Ok("Giriş başarılı");
			}
			return Ok("Kullanıcı adı veya şifre hatalı");
		}
	}
}
