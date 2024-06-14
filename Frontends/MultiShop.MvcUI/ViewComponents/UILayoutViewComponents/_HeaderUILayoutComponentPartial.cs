using Microsoft.AspNetCore.Mvc;

namespace MultiShop.MvcUI.ViewComponents.UILayoutViewComponents
{
    public class _HeaderUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
