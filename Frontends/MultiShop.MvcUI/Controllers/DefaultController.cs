using Microsoft.AspNetCore.Mvc;

namespace MultiShop.MvcUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
