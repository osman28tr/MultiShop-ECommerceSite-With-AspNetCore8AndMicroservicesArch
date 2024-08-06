using MultiShop.DtoLayer.IdentityDtos;

namespace MultiShop.MvcUI.Services.Abstract
{
    public interface IIdentityService
    {
        Task<bool> SignInAsync(SignInDto signInDto);
        Task<bool> GetRefreshToken();
    }
}
