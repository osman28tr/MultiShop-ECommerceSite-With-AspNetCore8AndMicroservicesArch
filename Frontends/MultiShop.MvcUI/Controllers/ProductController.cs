using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.MvcUI.Services.Repositories.CatalogServices.ProductServices.Abstract;
using MultiShop.MvcUI.Services.Repositories.CommentServices.Abstract;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IReviewService _reviewService;
        public ProductController(IProductService productService, IReviewService reviewService)
        {
            _productService = productService;
            _reviewService = reviewService;
        }
        public async Task<IActionResult> Index(string? id)
        {
            if (id == null)
            {
                var allProducts = await _productService.GetAllAsync();
                if (allProducts != null)
                    return View(allProducts);
                return View();
            }
            else
            {
                var productsByCategory = await _productService.GetListProductByCategory(id);
                if (productsByCategory != null)
                    return View(productsByCategory);
                return View();
            }
        }
        [HttpGet]
        [Route("Detail/{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            ViewBag.Id = id;
            HttpContext.Session.SetString("product_id", id);
            var values = await _productService.GetByIdProductAsync(id);
            if (values != null)
                return View(values);
            return View();
        }
        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(CreateReviewDto createReviewDto)
        {
            createReviewDto.User.Image = "images/osman_image1.jpg";
            createReviewDto.User.Id = "5dd62b26-874d-4fb2-997f-a6513d5b2230";
            createReviewDto.Status = true;
            createReviewDto.product_id = HttpContext.Session.GetString("product_id");

            var result = await _reviewService.SaveAsync(createReviewDto);
            if (result != null)
                return RedirectToAction("Index", "Default");
            return View();
        }
    }
}
