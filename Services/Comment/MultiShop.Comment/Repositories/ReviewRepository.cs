
using MultiShop.Comment.Models;
using MultiShop.Comment.Repositories.Abstract;
using MultiShop.Comment.ViewModels.ReviewViewModels;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using Elastic.Clients.Elasticsearch;
using Nest;

namespace MultiShop.Comment.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ElasticsearchClient _elasticClient;
        private readonly ElasticClient _elasticNestClient;
        private const string _reviewIndexName = "reviews";
        public ReviewRepository(ElasticsearchClient elasticClient, ElasticClient elasticNestClient)
        {
            _elasticClient = elasticClient;
            _elasticNestClient = elasticNestClient;
        }
        public async Task<IReadOnlyCollection<ResultReviewViewModel>> GetAllAsync()
        {
            var result =
                await _elasticClient.SearchAsync<Review>(x => x.Index(_reviewIndexName).Query(q => q.MatchAll()));

            foreach (var hit in result.Hits) hit.Source.Id = hit.Id;

            return result.Documents.Select(x => x.ConvertToResultReviewViewModel()).ToList();
        }

        public Task<IReadOnlyCollection<ResultReviewViewModel>> SearchAsync(string searchText)
        {
            throw new NotImplementedException();
        }

        public async Task<GetByIdReviewViewModel> GetByIdAsync(string id)
        {
            var response = await _elasticClient.GetAsync<Review>(id, x => x.Index
                (_reviewIndexName));
            if (!response.IsSuccess())
                return null;

            response.Source.Id = response.Id;

            return response.Source.ConvertToGetByIdReviewViewModel();
        }

        public async Task<ResultReviewViewModel> SaveAsync(CreatedReviewViewModel createdReviewViewModel)
        {
            createdReviewViewModel.CreatedDate = DateTime.Now;
            var review = createdReviewViewModel.ConvertToReviewModel();
            var response =
                await _elasticClient.IndexAsync(review, x => x.Index(_reviewIndexName).Id(Guid.NewGuid().ToString()));
            if (!response.IsSuccess())
                return null;
            var newReview = createdReviewViewModel.ConvertToReviewModel();
            newReview.Id = response.Id;
            return newReview.ConvertToResultReviewViewModel();
        }

        public async Task<bool> UpdateAsync(UpdateReviewViewModel updateReviewViewModel)
        {
            var response = await _elasticNestClient.UpdateAsync<Review, UpdateReviewViewModel
            >(updateReviewViewModel.Id, x => x
                .Index(_reviewIndexName)
                .Doc(updateReviewViewModel));
            return response.IsValid;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var response = await _elasticClient.DeleteAsync<Review>(id, x => x.Index(_reviewIndexName));
            return response.IsSuccess();
        }
    }
}
