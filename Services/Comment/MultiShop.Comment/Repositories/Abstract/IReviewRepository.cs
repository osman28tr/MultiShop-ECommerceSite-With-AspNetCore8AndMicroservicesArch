using MultiShop.Comment.ViewModels.ReviewViewModels;

namespace MultiShop.Comment.Repositories.Abstract
{
    public interface IReviewRepository
    {
        Task<IReadOnlyCollection<ResultReviewViewModel>> GetAllAsync();
        Task<IReadOnlyCollection<ResultReviewViewModel>> GetAllByProductAsync(string productId);
        Task<IReadOnlyCollection<ResultReviewViewModel>> SearchAsync(string searchText);
        Task<GetByIdReviewViewModel> GetByIdAsync(string id);
        Task<ResultReviewViewModel> SaveAsync(CreatedReviewViewModel createdReviewViewModel);
        Task<bool> UpdateAsync(UpdateReviewViewModel updateReviewViewModel);
        Task<bool> DeleteAsync(string id);
    }
}
