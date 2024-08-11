using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CustomerDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.CustomerServices.Abstract;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewbagCustomer("Müşteri Listesi");
            var values = await _customerService.GetAllAsync();
            return View(values);
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            ViewbagCustomer("Müşteri Girişi");
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateCustomerDto createCustomerDto)
        {
            await _customerService.AddAsync(createCustomerDto);
            return RedirectToAction("Index", "Customer", new { area = "Admin" });
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _customerService.DeleteAsync(id);
            return RedirectToAction("Index", "Customer", new { area = "Admin" });
        }

        [Route("Update/{id}")]
        public async Task<IActionResult> Update(string id)
        {
            ViewbagCustomer("Müşteri Güncelleme Sayfası");
            var values = await _customerService.GetByIdAsync(id);
            return View(values);
        }
        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(UpdateCustomerDto updateCustomerDto)
        {
            await _customerService.UpdateAsync(updateCustomerDto);
            return RedirectToAction("Index", "Customer", new { area = "Admin" });
        }

        void ViewbagCustomer(string headPage)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Müşteriler";
            ViewBag.v3 = headPage;
            ViewBag.v4 = "Müşteri İşlemleri";
        }
    }
}
