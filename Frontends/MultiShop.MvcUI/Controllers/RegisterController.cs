using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.Controllers
{
    public class RegisterController : Controller
    {
	    private readonly IHttpClientFactory _httpClientFactory;
	    private readonly HttpClient _httpClient;
	    private readonly string _identityUrl;
	    public RegisterController(IHttpClientFactory httpClientFactory)
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
        public async Task<IActionResult> Index(CreateRegisterDto registerDto)
        {
			var jsonData = JsonConvert.SerializeObject(registerDto);
			StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await _httpClient.PostAsync(_identityUrl + "/api/Registers", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Login");
			}
			return View();
		}
    }
}
