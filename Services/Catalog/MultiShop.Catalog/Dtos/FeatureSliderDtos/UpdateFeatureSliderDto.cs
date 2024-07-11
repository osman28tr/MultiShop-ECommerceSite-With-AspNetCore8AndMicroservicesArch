using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Dtos.FeatureSliderDtos
{
    public class UpdateFeatureSliderDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
