using Microsoft.AspNetCore.Mvc;

namespace MultiShop.MvcUI.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
