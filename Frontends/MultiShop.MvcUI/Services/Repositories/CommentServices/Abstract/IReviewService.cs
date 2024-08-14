using MultiShop.DtoLayer.CommentDtos;
using MultiShop.MvcUI.ViewModels;

namespace MultiShop.MvcUI.Services.Repositories.CommentServices.Abstract
{
    public interface IReviewService
    {
        Task<IReadOnlyCollection<ResultReviewDto>> GetAllAsync();
        Task<IReadOnlyCollection<ResultReviewDto>> GetAllByProductAsync(string productId);
        Task<ResultReviewDto> SaveAsync(CreateReviewDto createReviewDto);
        Task<IReadOnlyCollection<ResultReviewDto>> SearchAsync(SearchViewModel searchViewModel);
        Task<UpdateReviewDto> GetByIdAsync(string id);
        Task<bool> UpdateAsync(UpdateReviewDto updateReviewDto);
        Task<bool> DeleteAsync(string id);
    }
}
