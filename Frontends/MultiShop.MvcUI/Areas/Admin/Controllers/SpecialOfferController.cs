using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.SpecialOfferServices.Abstract;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;
        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewbagSpecialOffer("Özel Teklifler ve Günün İndirimi Listesi");
            var values = await _specialOfferService.GetAllAsync();
            return View(values);
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            ViewbagSpecialOffer("Yeni Özel Teklif Girişi");
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.AddAsync(createSpecialOfferDto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _specialOfferService.DeleteAsync(id);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        [Route("Update/{id}")]
        public async Task<IActionResult> Update(string id)
        {
            ViewbagSpecialOffer("Özel Teklifler Güncelleme İşlemi");
            var values = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            return View(values);
        }
        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateAsync(updateSpecialOfferDto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        void ViewbagSpecialOffer(string headPage)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = headPage;
            ViewBag.v4 = "Özel Teklif İşlemleri";
        }
    }
}
