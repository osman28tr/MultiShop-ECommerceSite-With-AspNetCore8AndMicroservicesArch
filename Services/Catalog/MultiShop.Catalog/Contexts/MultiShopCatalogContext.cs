using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Contexts
{
    public class MultiShopCatalogContext
    {
        private readonly IOptions<IDatabaseSetting> _databaseSettings;
        private readonly IMongoDatabase _database;
        public MultiShopCatalogContext(IOptions<IDatabaseSetting> databaseSetting)
        {
            _databaseSettings = databaseSetting;
            var client = new MongoClient(_databaseSettings.Value.ConnectionString);
            _database = client.GetDatabase(_databaseSettings.Value.DatabaseName);
        }
        public IMongoCollection<Category> Categories => _database.GetCollection<Category>(_databaseSettings.Value.CategoryCollectionName);
        public IMongoCollection<Product> Products => _database.GetCollection<Product>(_databaseSettings.Value.ProductCollectionName);
        public IMongoCollection<ProductDetail> ProductDetails => _database.GetCollection<ProductDetail>(_databaseSettings.Value.ProductDetailCollectionName);
        public IMongoCollection<ProductImage> ProductImages => _database.GetCollection<ProductImage>(_databaseSettings.Value.ProductImageCollectionName);
    }
}
