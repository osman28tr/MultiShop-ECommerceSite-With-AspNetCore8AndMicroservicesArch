namespace MultiShop.DtoLayer.DiscountDtos
{
    public class ApplyCouponDto
    {
        public string Code { get; set; }
        public List<string> ProductIds { get; set; }
    }
}
