using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MultiShop.MvcUI.Controllers
{
	public class TestController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly HttpClient _httpClient;
		private readonly string _catalogCategoryUrl;
		public TestController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
			_httpClient = _httpClientFactory.CreateClient();
			IConfiguration Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
			_catalogCategoryUrl = Configuration["CatalogAPI:CategoryUrl"]!;
		}
		public async Task<IActionResult> Index()
		{
			//httpclient isteğine token ekle
            string token = "";
            using var request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://localhost:5001/connect/token");
            request.Method = HttpMethod.Post;
            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["client_id"] = "MultiShopId",
                ["client_secret"] = "multishopsecret",
                ["grant_type"] = "client_credentials",
            });

            using var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var tokenReponse = JObject.Parse(content);
                token = tokenReponse["access_token"].Value<string>();
            }

			_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

			var responseMessage = await _httpClient.GetAsync(_catalogCategoryUrl);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
