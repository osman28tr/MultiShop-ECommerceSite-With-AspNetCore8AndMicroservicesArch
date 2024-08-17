﻿namespace MultiShop.DtoLayer.DiscountDtos
{
    public class CreateCouponDto
    {
        public string Code { get; set; }
        public string ProductId { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
