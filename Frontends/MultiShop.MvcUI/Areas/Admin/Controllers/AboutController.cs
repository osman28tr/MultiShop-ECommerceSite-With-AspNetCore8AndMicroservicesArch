using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly string _catalogAboutUrl;
        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
            IConfiguration Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _catalogAboutUrl = Configuration["CatalogAPI:AboutUrl"]!;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Hakkımda";
            ViewBag.v3 = "Hakkımda Listesi";
            ViewBag.v4 = "Hakkımda İşlemleri";
            var responseMessage = await _httpClient.GetAsync(_catalogAboutUrl);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Hakkımda";
            ViewBag.v3 = "Hakkımda Girişi";
            ViewBag.v4 = "Hakkımda İşlemleri";
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateAboutDto createAboutDto)
        {
            var jsonData = JsonConvert.SerializeObject(createAboutDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync(_catalogAboutUrl, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), "About", new { area = "Admin" });
            }
            return View();
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync(_catalogAboutUrl + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), "About", new { area = "Admin" });
            }
            return View();
        }

        [Route("Update/{id}")]
        public async Task<IActionResult> Update(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Hakkımda";
            ViewBag.v3 = "Hakkımda Güncelleme Sayfası";
            ViewBag.v4 = "Hakkımda İşlemleri";
            var responseMessage = await _httpClient.GetAsync(_catalogAboutUrl + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
        {
            var jsonData = JsonConvert.SerializeObject(updateAboutDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PutAsync(_catalogAboutUrl, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), "About", new { area = "Admin" });
            }
            return View();
        }
    }
}
