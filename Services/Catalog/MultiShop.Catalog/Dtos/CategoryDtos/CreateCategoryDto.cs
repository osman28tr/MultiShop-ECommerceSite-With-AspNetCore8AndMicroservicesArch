using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
