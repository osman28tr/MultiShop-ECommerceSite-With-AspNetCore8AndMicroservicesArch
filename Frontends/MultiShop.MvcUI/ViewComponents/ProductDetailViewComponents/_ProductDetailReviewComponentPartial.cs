using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.MvcUI.Services.Repositories.CommentServices.Abstract;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial : ViewComponent
    {
        private readonly IReviewService _reviewService;
        public _ProductDetailReviewComponentPartial(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            var values = await _reviewService.GetAllByProductAsync(productId);
            ViewBag.Id = productId;
            if (values != null)
                return View(values.ToList());
            return View();
        }
    }
}
