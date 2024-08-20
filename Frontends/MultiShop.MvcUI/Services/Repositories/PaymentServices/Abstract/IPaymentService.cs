using MultiShop.DtoLayer.PaymentDtos;

namespace MultiShop.MvcUI.Services.Repositories.PaymentServices.Abstract
{
    public interface IPaymentService
    {
        Task<bool> Pay(PaymentDto paymentDto);
    }
}
