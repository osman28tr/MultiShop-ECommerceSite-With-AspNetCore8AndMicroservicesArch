using Microsoft.AspNetCore.Mvc;

namespace MultiShop.MvcUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
