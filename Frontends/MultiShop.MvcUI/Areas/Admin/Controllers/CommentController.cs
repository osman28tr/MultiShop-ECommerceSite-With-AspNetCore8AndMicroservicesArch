using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.MvcUI.Areas.Admin.Models;
using MultiShop.MvcUI.Services.Repositories.CommentServices.Abstract;
using MultiShop.MvcUI.ViewModels;
using Newtonsoft.Json;

namespace MultiShop.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
        private readonly IReviewService _reviewService;
        public CommentController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewbagComment("Yorum Listesi");
            var values = await _reviewService.GetAllAsync();
            if(values != null)
                return View(values.ToList());
            return View();
        }
        [Route("Index")]
        [HttpPost]
        public async Task<IActionResult> Index(SearchViewModel searchCommentModel)
        {
            var values = await _reviewService.SearchAsync(searchCommentModel);
            if(values != null)
                return View(values.ToList());
            return View();
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _reviewService.DeleteAsync(id);
            if (response)
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            return View();
        }

        [Route("Update/{id}")]
        public async Task<IActionResult> Update(string id)
        {
            ViewbagComment("Yorum Güncelleme Sayfası");
            var values = await _reviewService.GetByIdAsync(id);
            if(values!= null)
                return View(values);
            return View();
        }
        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(UpdateReviewDto updateReviewDto)
        {
            var response = await _reviewService.UpdateAsync(updateReviewDto);
            if (response)
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            return View();
        }

        void ViewbagComment(string headPage)
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = headPage;
            ViewBag.v4 = "Yorum İşlemleri";
        }
    }
}
