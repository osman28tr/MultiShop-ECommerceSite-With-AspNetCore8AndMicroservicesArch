using MultiShop.MvcUI.Models;

namespace MultiShop.MvcUI.Services.Abstract
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
    }
}
