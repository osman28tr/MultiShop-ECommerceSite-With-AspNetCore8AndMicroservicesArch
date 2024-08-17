namespace MultiShop.Basket.Dtos
{
    public class BasketDto
    {
        public string UserId { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
        public decimal TotalPrice { get => BasketItems.Sum(x => x.Quantity * x.Price); }
        public BasketDto()
        {
            BasketItems = new List<BasketItemDto>();
        }
    }
}
