using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly string _catalogProductImageUrl;
        public _ProductDetailImageSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
            IConfiguration Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _catalogProductImageUrl = Configuration["CatalogAPI:ProductDetailImageUrl"]!;
        }
        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            var responseMessage = await _httpClient.GetAsync(_catalogProductImageUrl + $"/GetListByProductId/{productId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
