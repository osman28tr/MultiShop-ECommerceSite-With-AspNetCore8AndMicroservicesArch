using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.Serialization;
using Elastic.Transport;
using Elasticsearch.Net;
using MultiShop.Comment.Models;
using Nest;

namespace MultiShop.Comment.Extensions
{
    public static class ElasticSearchEx
    {
        public static void AddElastic(this IServiceCollection services, IConfiguration configuration)
        {
            var settings =
                new ElasticsearchClientSettings(
                    new SingleNodePool(new Uri(configuration.GetSection("ElasticSearchDb")["Url"]!)));
            var client = new ElasticsearchClient(settings);

            var nestClient = new ElasticClient(new ConnectionSettings(
                new SingleNodeConnectionPool(new Uri(configuration.GetSection("ElasticSearchDb")["Url"]!))));

            services.AddSingleton(client);
            services.AddSingleton(nestClient);
        }
    }
}
