﻿namespace MultiShop.DtoLayer.BasketDtos
{
    public class BasketDto
    {
        public string UserId { get; set; }
        public string? DiscountCode { get; set; }
        public int? DiscountRate { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
        public decimal TotalPrice { get => BasketItems.Sum(x => x.Quantity * x.Price); }
        public BasketDto()
        {
            BasketItems = new List<BasketItemDto>();
        }
    }
}
