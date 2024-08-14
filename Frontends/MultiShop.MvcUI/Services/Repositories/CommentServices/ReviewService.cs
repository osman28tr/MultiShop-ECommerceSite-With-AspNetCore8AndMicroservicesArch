using MultiShop.DtoLayer.CommentDtos;
using MultiShop.MvcUI.Services.Repositories.CommentServices.Abstract;
using MultiShop.MvcUI.ViewModels;

namespace MultiShop.MvcUI.Services.Repositories.CommentServices
{
    public class ReviewService : IReviewService
    {
        private readonly HttpClient _httpClient;
        public ReviewService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IReadOnlyCollection<ResultReviewDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultReviewDto>>("comments");
        }

        public async Task<IReadOnlyCollection<ResultReviewDto>> GetAllByProductAsync(string productId)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultReviewDto>>($"comments/GetListByProduct/{productId}");
            return response;
        }

        public async Task<IReadOnlyCollection<ResultReviewDto>> SearchAsync(SearchViewModel searchViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync<SearchViewModel>("comments/Search", searchViewModel);
            return await response.Content.ReadFromJsonAsync<List<ResultReviewDto>>();
        }

        public async Task<UpdateReviewDto> GetByIdAsync(string reviewId)
        {
            return await _httpClient.GetFromJsonAsync<UpdateReviewDto>($"comments/{reviewId}");
        }

        public async Task<ResultReviewDto> SaveAsync(CreateReviewDto createReviewDto)
        {
           var response = await _httpClient.PostAsJsonAsync<CreateReviewDto>("comments", createReviewDto);
           return await response.Content.ReadFromJsonAsync<ResultReviewDto>();
        }

        public async Task<bool> UpdateAsync(UpdateReviewDto updateReviewDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"comments", updateReviewDto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string reviewId)
        {
            var response = await _httpClient.DeleteAsync($"comments/{reviewId}");
            return response.IsSuccessStatusCode;
        }
    }
}
