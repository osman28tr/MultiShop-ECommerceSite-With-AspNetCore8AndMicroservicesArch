using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.DtoLayer.CatalogDtos.ProductDtos
{
    public class ResultProductWithCategoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryId { get; set; }
        public ResultCategoryDto Category { get; set; }
    }
}
