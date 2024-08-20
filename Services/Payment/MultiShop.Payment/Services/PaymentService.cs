using MultiShop.Payment.Dtos;
using MultiShop.Payment.Services.Abstract;

namespace MultiShop.Payment.Services
{
    public class PaymentService : IPaymentService
    {
        public async Task<bool> OrderPay(PaymentDto paymentDto)
        {
            return true;
        }
    }
}
