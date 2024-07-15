using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CustomerDtos;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Customer")]
    public class CustomerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly string _catalogCustomerUrl;
        public CustomerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
            IConfiguration Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _catalogCustomerUrl = Configuration["CatalogAPI:CustomerUrl"]!;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Müşteriler";
            ViewBag.v3 = "Müşteri Listesi";
            ViewBag.v4 = "Müşteri İşlemleri";
            var responseMessage = await _httpClient.GetAsync(_catalogCustomerUrl);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCustomerDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Müşteriler";
            ViewBag.v3 = "Müşteri Girişi";
            ViewBag.v4 = "Müşteri İşlemleri";
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateCustomerDto createCustomerDto)
        {
            var jsonData = JsonConvert.SerializeObject(createCustomerDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync(_catalogCustomerUrl, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Customer", new { area = "Admin" });
            }
            return View();
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync(_catalogCustomerUrl + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Customer", new { area = "Admin" });
            }
            return View();
        }

        [Route("Update/{id}")]
        public async Task<IActionResult> Update(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Müşteriler";
            ViewBag.v3 = "Müşteri Güncelleme Sayfası";
            ViewBag.v4 = "Müşteri İşlemleri";
            var responseMessage = await _httpClient.GetAsync(_catalogCustomerUrl + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCustomerDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(UpdateCustomerDto updateCustomerDto)
        {
            var jsonData = JsonConvert.SerializeObject(updateCustomerDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PutAsync(_catalogCustomerUrl, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Customer", new { area = "Admin" });
            }
            return View();
        }
    }
}
