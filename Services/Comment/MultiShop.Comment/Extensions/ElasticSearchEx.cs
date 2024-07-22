using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

namespace MultiShop.Comment.Extensions
{
    public static class ElasticSearchEx
    {
        public static void AddElastic(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["ElasticSearchDb:Url"]!;

            var settings = new ElasticsearchClientSettings(new SingleNodePool(new Uri(url)));

            var elasticSearchClient = new ElasticsearchClient(settings);

            services.AddSingleton(elasticSearchClient);
        }
    }
}
