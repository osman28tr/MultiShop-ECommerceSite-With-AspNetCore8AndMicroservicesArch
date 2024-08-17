namespace MultiShop.Discount.Dtos
{
    public class ApplyCouponDto
    {
        public string Code { get; set; }
        public List<string> ProductIds { get; set; }
    }
}
