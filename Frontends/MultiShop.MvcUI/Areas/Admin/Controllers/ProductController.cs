using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly string _catalogProductUrl;
        private readonly string _catalogCategoryUrl;
        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
            IConfiguration Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _catalogProductUrl = Configuration["CatalogAPI:ProductUrl"]!;
            _catalogCategoryUrl = Configuration["CatalogAPI:CategoryUrl"]!;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v4 = "Ürün İşlemleri";
            var responseMessage = await _httpClient.GetAsync(_catalogProductUrl);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Ekleme";
            ViewBag.v4 = "Ürün İşlemleri";
            var responseMessage = await _httpClient.GetAsync(_catalogCategoryUrl);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> categoryList = (from x in values
                select new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id
                }).ToList();
            ViewBag.CategoryList = categoryList;
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync(_catalogProductUrl, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
