using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.OfferDiscountServices.Abstract;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IOfferDiscountService _offerDiscountService;
        public OfferDiscountController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewbagOfferDiscount("İndirim Teklif Listesi");
            var values = await _offerDiscountService.GetAllAsync();
            return View(values);
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            ViewbagOfferDiscount("İndirim Teklif Listesi Girişi");
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountService.AddAsync(createOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _offerDiscountService.DeleteAsync(id);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }

        [Route("Update/{id}")]
        public async Task<IActionResult> Update(string id)
        {
            ViewbagOfferDiscount("İndirim Teklif Listesi Güncelleme Sayfası");
            var values = await _offerDiscountService.GetByIdAsync(id);
            return View(values);
        }
        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountService.UpdateAsync(updateOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }

        void ViewbagOfferDiscount(string headPage)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "İndirim Teklifleri";
            ViewBag.v3 = headPage;
            ViewBag.v4 = "İndirim Teklif İşlemleri";
        }
    }
}
