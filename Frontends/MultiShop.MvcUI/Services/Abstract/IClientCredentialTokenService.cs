namespace MultiShop.MvcUI.Services.Abstract
{
    public interface IClientCredentialTokenService
    {
        Task<string> GetToken();
    }
}
