using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;
using System.Text;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace MultiShop.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly string _catalogProductImagesUrl;
        private readonly string _catalogProductDetailUrl;
        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
            IConfiguration Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _catalogProductImagesUrl = Configuration["CatalogAPI:ProductDetailImageUrl"]!;
            _catalogProductDetailUrl = Configuration["CatalogAPI:ProductDetailUrl"]!;
        }
        [HttpGet]
        [Route("Index/{productId}")]
        public async Task<IActionResult> Index(string productId)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürün Açıklamaları";
            ViewBag.v3 = "Ürün Açıklama Sayfası";
            ViewBag.v4 = "Ürün Açıklama İşlemleri";
            ViewBag.ProductId = productId;
            var responseMessage = await _httpClient.GetAsync(_catalogProductDetailUrl + "/GetByProduct/" + productId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultProductDetailDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("Index/{productId}")]
        public async Task<IActionResult> Index(ResultProductDetailDto resultProductDetailDto)
        {
            UpdateProductDetailDto updateProductDetailDto = new()
            {
                Id = resultProductDetailDto.Id,
                Description = resultProductDetailDto.Description,
                Info = resultProductDetailDto.Info,
                ProductId = resultProductDetailDto.ProductId
            };
            var jsonData = JsonConvert.SerializeObject(updateProductDetailDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PutAsync(_catalogProductDetailUrl, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("Create/{productId}")]
        public IActionResult Create(string productId)
        {
            ViewBag.ProductId = productId;
            return View();
        }
        [HttpPost]
        [Route("Create/{productId}")]
        public async Task<IActionResult> Create(string productId, CreateProductDetailDto createProductDetailDto)
        {
            createProductDetailDto.ProductId = productId;
            var jsonData = JsonConvert.SerializeObject(createProductDetailDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync(_catalogProductDetailUrl, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet]
        [Route("ProductDetailImage/{productId}")]
        public async Task<IActionResult> ProductDetailImage(string productId)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürün Görselleri";
            ViewBag.v3 = "Ürün Görsel Güncelleme Sayfası";
            ViewBag.v4 = "Ürün Görsel İşlemleri";
            var responseMessage = await _httpClient.GetAsync(_catalogProductImagesUrl + "/GetListByProductId/" + productId);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("ProductDetailImage/{productId}")]
        public async Task<IActionResult> ProductDetailImage(ResultProductImageDto updateProductImageDto)
        {
            var jsonData = JsonConvert.SerializeObject(updateProductImageDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PutAsync(_catalogProductImagesUrl, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }

    }
}
