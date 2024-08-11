using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.FeatureServices.Abstract;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;
        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewbagFeature("Öne Çıkan Alan Listesi");
            var values = await _featureService.GetAllAsync();
            return View(values);
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            ViewbagFeature("Öne Çıkan Alan Girişi");
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateFeatureDto createFeatureDto)
        {
            await _featureService.AddAsync(createFeatureDto);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _featureService.DeleteAsync(id);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }

        [Route("Update/{id}")]
        public async Task<IActionResult> Update(string id)
        {
            ViewbagFeature("Öne Çıkan Alan Güncelleme Sayfası");
            var values = await _featureService.GetByIdFeatureAsync(id);
            return View(values);
        }
        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.UpdateAsync(updateFeatureDto);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }

        void ViewbagFeature(string headPage)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Öne Çıkan Alanlar";
            ViewBag.v3 = headPage;
            ViewBag.v4 = "Anasayfa Öne Çıkan Alan İşlemleri";
        }
    }
}
