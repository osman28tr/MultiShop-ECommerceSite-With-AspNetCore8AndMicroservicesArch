using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly string _catalogProductUrl;
        private readonly string _commentUrl;
        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
            IConfiguration Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _catalogProductUrl = Configuration["CatalogAPI:ProductUrl"]!;
            _commentUrl = Configuration["CommentUrl"]!;
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
        [HttpGet]
        [Route("Detail/{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            ViewBag.Id = id;
            HttpContext.Session.SetString("product_id",id);
            HttpResponseMessage responseMessage;
            responseMessage = await _httpClient.GetAsync(_catalogProductUrl + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(CreateReviewDto createReviewDto)
        {
            createReviewDto.User.Image = "images/osman_image1.jpg";
            createReviewDto.User.Id = "5dd62b26-874d-4fb2-997f-a6513d5b2230";
            createReviewDto.Status = true;
            createReviewDto.product_id = HttpContext.Session.GetString("product_id");
            var jsonData = JsonConvert.SerializeObject(createReviewDto);
            StringContent stringContent = new(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync(_commentUrl, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
