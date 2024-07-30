using MultiShop.Comment.ViewModels.ReviewViewModels;

namespace MultiShop.Comment.Services.Abstract
{
    public interface IReviewService
    {
        Task<IReadOnlyCollection<ResultReviewViewModel>> GetAllAsync();
        Task<IReadOnlyCollection<ResultReviewViewModel>> GetAllByProductAsync(string productId);
        Task<IReadOnlyCollection<ResultReviewViewModel>> SearchAsync(SearchViewModel searchViewModel);
        Task<GetByIdReviewViewModel> GetByIdAsync(string id);
        Task<ResultReviewViewModel> SaveAsync(CreatedReviewViewModel createdReviewViewModel);
        Task<bool> UpdateAsync(UpdateReviewViewModel updateReviewViewModel);
        Task<bool> DeleteAsync(string id);
    }
}
