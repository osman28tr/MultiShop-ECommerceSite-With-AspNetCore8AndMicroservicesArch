using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Contexts
{
    public class MultiShopCatalogContext
    {
        private readonly IDatabaseSetting _databaseSettings;
        private readonly IMongoDatabase _database;
        public MultiShopCatalogContext(IDatabaseSetting databaseSetting)
        {
            _databaseSettings = databaseSetting;
            var client = new MongoClient(_databaseSettings.ConnectionString);
            _database = client.GetDatabase(_databaseSettings.DatabaseName);
        }
        public IMongoCollection<Category> Categories => _database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        public IMongoCollection<Product> Products => _database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        public IMongoCollection<ProductDetail> ProductDetails => _database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
        public IMongoCollection<ProductImage> ProductImages => _database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
        public IMongoCollection<FeatureSlider> FeatureSliders => _database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);
    }
}
