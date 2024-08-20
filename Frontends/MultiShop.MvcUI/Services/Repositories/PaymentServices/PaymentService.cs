using MultiShop.DtoLayer.PaymentDtos;
using MultiShop.MvcUI.Services.Repositories.PaymentServices.Abstract;

namespace MultiShop.MvcUI.Services.Repositories.PaymentServices
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;
        public PaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> Pay(PaymentDto paymentDto)
        {
            var response = await _httpClient.PostAsJsonAsync("payments", paymentDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
