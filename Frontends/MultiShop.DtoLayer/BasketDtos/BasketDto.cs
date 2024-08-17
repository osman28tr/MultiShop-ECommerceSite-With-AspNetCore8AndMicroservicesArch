namespace MultiShop.DtoLayer.BasketDtos
{
    public class BasketDto
    {
        public string UserId { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
        public decimal TotalPrice
        {
            get => BasketItems.Sum(x => x.Price * x.Quantity);
        }
        public BasketDto()
        {
            BasketItems = new List<BasketItemDto>();
        }
    }
}
