using MultiShop.MvcUI.Models;
using MultiShop.MvcUI.Services.Abstract;

namespace MultiShop.MvcUI.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDetailViewModel> GetUserInfo()
        {
            return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuserinfo");
        }
    }
}
