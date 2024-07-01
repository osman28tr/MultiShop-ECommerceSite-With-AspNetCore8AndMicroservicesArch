using Microsoft.AspNetCore.Mvc;

namespace MultiShop.MvcUI.ViewComponents.ProductViewComponents
{
    public class _ProductListBySizeFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
