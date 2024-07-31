using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos;
using MultiShop.MvcUI.Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MultiShop.MvcUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly HttpClient _httpClient;
		private readonly string _identityUrl;
		public LoginController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
			_httpClient = _httpClientFactory.CreateClient();
			IConfiguration Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
			_identityUrl = Configuration["IdentityUrl"]!;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateLoginDto loginDto)
		{
			StringContent stringContent = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");
			var responseMessage = await _httpClient.PostAsync(_identityUrl + "/api/Logins", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions()
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				});
				if (tokenModel != null)
				{
					JwtSecurityTokenHandler handler = new();
					var token = handler.ReadJwtToken(tokenModel.Token);
					var claims = token.Claims.ToList();

					if (tokenModel.Token != null)
					{
						claims.Add(new Claim("multishoptoken", tokenModel.Token));
						var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
						var authProps = new AuthenticationProperties()
							{ ExpiresUtc = tokenModel.ExpiredDate, IsPersistent = true };
						await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme,
							new ClaimsPrincipal(claimsIdentity), authProps);
						return RedirectToAction("Index", "Default");
					}
				}
			}
			return View();
		}
	}
}
