using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.FeatureSliderServices.Abstract;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IFeatureSliderService _featureSliderService;
        public FeatureSliderController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewbagFeatureSlider("Slider Öne Çıkan Görsel Listesi");
            var values = await _featureSliderService.GetAllAsync();
            return View(values);
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            ViewbagFeatureSlider("Yeni Öne Çıkan Görsel Girişi");
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateFeatureSliderDto createFeatureSliderDto)
        {
            createFeatureSliderDto.Status = false;
            await _featureSliderService.AddAsync(createFeatureSliderDto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _featureSliderService.DeleteAsync(id);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }

        [Route("Update/{id}")]
        public async Task<IActionResult> Update(string id)
        {
            ViewbagFeatureSlider("Öne Çıkan Görsel Güncelleme Sayfası");
            var values = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return View(values);
        }
        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _featureSliderService.UpdateAsync(updateFeatureSliderDto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }

        void ViewbagFeatureSlider(string headPage)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan Görseller";
            ViewBag.v3 = headPage;
            ViewBag.v4 = "Öne Çıkan Görsel İşlemleri";
        }
    }
}
