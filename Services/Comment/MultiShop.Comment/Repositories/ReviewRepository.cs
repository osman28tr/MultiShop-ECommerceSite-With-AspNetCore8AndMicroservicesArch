
using MultiShop.Comment.Models;
using MultiShop.Comment.Repositories.Abstract;
using MultiShop.Comment.ViewModels.ReviewViewModels;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using Elastic.Clients.Elasticsearch;
using Nest;
using Review = MultiShop.Comment.Models.Review;
using Elastic.Clients.Elasticsearch.QueryDsl;
using System.Reflection.Metadata;

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

		public async Task<IReadOnlyCollection<ResultReviewViewModel>> GetAllByProductAsync(string productId)
		{
			var result = await _elasticClient.SearchAsync<Review>(x => x.Index(_reviewIndexName)
						   .Query(q => q.Term(t => t.Field(f => f.ProductId).Value(productId))));

			foreach (var hit in result.Hits) hit.Source.Id = hit.Id;

			return result.Documents.Select(x => x.ConvertToResultReviewViewModel()).ToList();
		}

		public async Task<IReadOnlyCollection<ResultReviewViewModel>> SearchAsync(SearchViewModel searchViewModel)
		{
			List<Action<QueryDescriptor<Review>>> ListQuery = new();

			Action<QueryDescriptor<Review>> matchAll = (q) => q.MatchAll();

			Action<QueryDescriptor<Review>> matchContent = (q) => q.Match(m => m
			.Field(f => f.Content)
			.Query(searchViewModel.Content));

			Action<QueryDescriptor<Review>> ratingTerm = (q) => q.Term(m => m
			.Field(f => f.Rating)
			.Value(searchViewModel.Rating));

			Action<QueryDescriptor<Review>> statusTerm = (q) => q.Term(t => t.Field(f => f.Status).Value(searchViewModel.Status));

			Action<QueryDescriptor<Review>> productTerm = (q) => q.Term(t => t.Field(f => f.ProductId).Value(searchViewModel.ProductId));

			Action<QueryDescriptor<Review>> usernameTerm = (q) =>
				q.Term(t => t.Field(f => f.User.Name).Value(searchViewModel.UserName));

			if (string.IsNullOrEmpty(searchViewModel.Content) && searchViewModel.Rating == 0 && string.IsNullOrEmpty(searchViewModel.ProductId) && searchViewModel.Status == true && string.IsNullOrEmpty(searchViewModel.UserName))
			{
				ListQuery.Add(matchAll);
			}
			else
			{
				if(!string.IsNullOrEmpty(searchViewModel.Content))
					ListQuery.Add(matchContent);
				if(searchViewModel.Rating != 0)
					ListQuery.Add(ratingTerm);
				if(!string.IsNullOrEmpty(searchViewModel.ProductId))
					ListQuery.Add(productTerm);
				if (!searchViewModel.Status)
					ListQuery.Add(statusTerm);
				if (!string.IsNullOrEmpty(searchViewModel.UserName))
					ListQuery.Add(usernameTerm);
			}
			var result = await _elasticClient.SearchAsync<Review>(s => s.Index(_reviewIndexName)
				.Size(1000).Query(q => q
					.Bool(b => b
						.Must(ListQuery.ToArray()))));

			foreach (var hit in result.Hits) hit.Source.Id = hit.Id;
			var searchReviews = result.Documents.ToList();
			return searchReviews.Select(x => x.ConvertToResultReviewViewModel()).ToList();
		} 
		public async Task<GetByIdReviewViewModel> GetByIdAsync(string id)
		{
			var response = await _elasticClient.GetAsync<Review>(id, x => x.Index
				(_reviewIndexName));
			if (!response.IsSuccess())
				return null;
			if (response != null)
			{
				response.Source.Id = response.Id;
				return response.Source.ConvertToGetByIdReviewViewModel();
			}
			return null;
		}

		public async Task<ResultReviewViewModel> SaveAsync(CreatedReviewViewModel createdReviewViewModel)
		{
			createdReviewViewModel.created_date = DateTime.Now;
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
			var review = updateReviewViewModel.ConvertToReviewModel();
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
