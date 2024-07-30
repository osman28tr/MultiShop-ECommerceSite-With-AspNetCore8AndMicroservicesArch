using Microsoft.AspNetCore.Mvc;

namespace MultiShop.MvcUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
