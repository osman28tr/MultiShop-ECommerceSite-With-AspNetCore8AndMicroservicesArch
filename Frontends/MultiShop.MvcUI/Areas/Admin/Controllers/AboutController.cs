using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.AboutServices.Abstract;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewbagAbout("Hakkımda Listesi");
            var values = await _aboutService.GetAllAsync();
            return View(values);
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            ViewbagAbout("Hakkımda Girişi");
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateAboutDto createAboutDto)
        {
            await _aboutService.AddAsync(createAboutDto);
            return RedirectToAction(nameof(Index), "About", new { area = "Admin" });
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _aboutService.DeleteAsync(id);
            return RedirectToAction(nameof(Index), "About", new { area = "Admin" });
        }

        [Route("Update/{id}")]
        public async Task<IActionResult> Update(string id)
        {
            ViewbagAbout("Hakkımda Güncelleme Sayfası");
            var values = await _aboutService.GetByIdAsync(id);
            return View(values);
        }
        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAsync(updateAboutDto);
            return RedirectToAction(nameof(Index), "About", new { area = "Admin" });
        }

        void ViewbagAbout(string headPage)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Hakkımda";
            ViewBag.v3 = headPage;
            ViewBag.v4 = "Hakkımda İşlemleri";
        }
    }
}
