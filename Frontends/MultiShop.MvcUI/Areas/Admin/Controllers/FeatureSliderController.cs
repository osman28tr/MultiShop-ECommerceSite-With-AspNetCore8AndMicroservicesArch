using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly string _catalogFeatureSliderUrl;
        public FeatureSliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
            IConfiguration Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _catalogFeatureSliderUrl = Configuration["CatalogAPI:FeatureSliderUrl"]!;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan Görseller";
            ViewBag.v3 = "Slider Öne Çıkan Görsel Listesi";
            ViewBag.v4 = "Öne Çıkan Slider Görsel İşlemleri";
            //httpclient isteğine token ekle
            var responseMessage = await _httpClient.GetAsync(_catalogFeatureSliderUrl);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan Görseller";
            ViewBag.v3 = "Yeni Öne Çıkan Görsel Girişi";
            ViewBag.v4 = "Öne Çıkan Görsel İşlemleri";
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateFeatureSliderDto createFeatureSliderDto)
        {
            createFeatureSliderDto.Status = false;
            var jsonData = JsonConvert.SerializeObject(createFeatureSliderDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync(_catalogFeatureSliderUrl, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            return View();
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync(_catalogFeatureSliderUrl + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            return View();
        }

        [Route("Update/{id}")]
        public async Task<IActionResult> Update(string id)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan Görseller";
            ViewBag.v3 = "Öne Çıkan Görsel Güncelleme Sayfası";
            ViewBag.v4 = "Öne Çıkan Görsel İşlemleri";
            var responseMessage = await _httpClient.GetAsync(_catalogFeatureSliderUrl + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var jsonData = JsonConvert.SerializeObject(updateFeatureSliderDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PutAsync(_catalogFeatureSliderUrl, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            return View();
        }
    }
}
