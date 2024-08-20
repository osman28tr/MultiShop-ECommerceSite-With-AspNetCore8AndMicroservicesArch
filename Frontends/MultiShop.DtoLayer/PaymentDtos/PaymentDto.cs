using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.PaymentDtos
{
    public class PaymentDto
    {
        public string CardOwner { get; set; }
        public DateTime CardExpiration { get; set; }
        public string Cvv { get; set; }
        public string CardNumber { get; set; }
        public string CardExpirationYear { get; set; }
        public string CardExpirationMonth { get; set; }
    }
}
