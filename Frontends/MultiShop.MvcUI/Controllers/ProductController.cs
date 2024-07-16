using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly string _catalogProductUrl;
        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
            IConfiguration Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _catalogProductUrl = Configuration["CatalogAPI:ProductUrl"]!;
        }
        public async Task<IActionResult> Index(string? id)
        {
            HttpResponseMessage responseMessage;
            if (id == null)
                responseMessage = await _httpClient.GetAsync(_catalogProductUrl);
            else
                responseMessage = await _httpClient.GetAsync(_catalogProductUrl + $"/GetListByCategory/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
