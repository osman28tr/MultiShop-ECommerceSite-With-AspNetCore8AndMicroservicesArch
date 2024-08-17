namespace MultiShop.DtoLayer.DiscountDtos
{
    public class GetByIdCouponDto
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
