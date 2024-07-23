using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Services.Abstract;
using MultiShop.Comment.ViewModels.ReviewViewModels;

namespace MultiShop.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public CommentsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _reviewService.GetAllAsync();
            if(result == null)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _reviewService.GetByIdAsync(id);
            if(result == null)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(result);
        }

        [HttpGet("GetListByProduct/{productId}")]
        public async Task<IActionResult> GetListByProduct(string productId)
        {
            var result = await _reviewService.GetAllByProductAsync(productId);
            if(result == null)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Save(CreatedReviewViewModel createdReviewViewModel)
        {
            var result = await _reviewService.SaveAsync(createdReviewViewModel);
            if(result == null)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateReviewViewModel updateReviewViewModel)
        {
            var result = await _reviewService.UpdateAsync(updateReviewViewModel);
            if(!result)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _reviewService.DeleteAsync(id);
            if(!result)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string searchText)
        {
            var result = await _reviewService.SearchAsync(searchText);
            return Ok(result);
        }
    }
}
