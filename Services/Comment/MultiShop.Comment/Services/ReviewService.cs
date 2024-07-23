using MultiShop.Comment.Repositories.Abstract;
using MultiShop.Comment.Services.Abstract;
using MultiShop.Comment.ViewModels.ReviewViewModels;

namespace MultiShop.Comment.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<IReadOnlyCollection<ResultReviewViewModel>> GetAllAsync()
        {
            return await _reviewRepository.GetAllAsync();
        }

        public async Task<IReadOnlyCollection<ResultReviewViewModel>> SearchAsync(string searchText)
        {
            return await _reviewRepository.SearchAsync(searchText);
        }

        public async Task<GetByIdReviewViewModel> GetByIdAsync(string id)
        {
            return await _reviewRepository.GetByIdAsync(id);
        }

        public async Task<ResultReviewViewModel> SaveAsync(CreatedReviewViewModel createdReviewViewModel)
        {
            return await _reviewRepository.SaveAsync(createdReviewViewModel);
        }

        public async Task<bool> UpdateAsync(UpdateReviewViewModel updateReviewViewModel)
        {
            return await _reviewRepository.UpdateAsync(updateReviewViewModel);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _reviewRepository.DeleteAsync(id);
        }
    }
}
