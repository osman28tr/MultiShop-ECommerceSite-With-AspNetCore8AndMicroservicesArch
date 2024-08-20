using MultiShop.DtoLayer.OrderDtos;

namespace MultiShop.MvcUI.Services.Repositories.OrderServices.Abstract
{
    public interface IOrderService
    {
        Task CreateAsync(CreateOrderDto createOrderDto);
    }
}
