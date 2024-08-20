using MultiShop.Payment.Dtos;

namespace MultiShop.Payment.Services.Abstract
{
    public interface IPaymentService
    {
        Task<bool> OrderPay(PaymentDto paymentDto);
    }
}
