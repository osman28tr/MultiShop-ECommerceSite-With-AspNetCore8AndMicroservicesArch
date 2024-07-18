﻿using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryId { get; set; }
        public ResultCategoryDto Category { get; set; }
    }
}
