using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.PaymentDtos;
using MultiShop.MvcUI.Services.Repositories.PaymentServices.Abstract;

namespace MultiShop.MvcUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(PaymentDto paymentDto)
        {
            paymentDto.CardExpiration = new DateTime(Convert.ToInt32(paymentDto.CardExpirationYear),
                Convert.ToInt32(paymentDto.CardExpirationMonth), 1);
            var result = await _paymentService.Pay(paymentDto);
            if (result)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
