using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
using Microsoft.Extensions.Options;
using MultiShop.MvcUI.Services.Abstract;
using MultiShop.MvcUI.Settings;

namespace MultiShop.MvcUI.Services
{
    public class ClientCredentialTokenService : IClientCredentialTokenService
    {
        private readonly ServiceApiSetting _serviceApiSetting;
        private readonly HttpClient _httpClient;
        private readonly IClientAccessTokenCache _clientAccessTokenCache;
        private readonly ClientSetting _clientSetting;
        public ClientCredentialTokenService(ServiceApiSetting serviceApiSetting, HttpClient httpClient,
            IClientAccessTokenCache clientAccessTokenCache, IOptions<ClientSetting> clientSetting)
        {
            _serviceApiSetting = serviceApiSetting;
            _httpClient = httpClient;
            _clientAccessTokenCache = clientAccessTokenCache;
            _clientSetting = clientSetting.Value;
        }
        public async Task<string> GetToken()
        {
            var currentToken = await _clientAccessTokenCache.GetAsync("multishoptoken");
            if (currentToken != null)
            {
                return currentToken.AccessToken;
            }

            var discoveryDocument = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest()
            {
                Address = _serviceApiSetting.IdentityUrl,
                Policy = new DiscoveryPolicy()
                {
                    RequireHttps = false
                }
            });

            var clientCredentialTokenRequest = new ClientCredentialsTokenRequest()
            {
                ClientId = _clientSetting.MultiShopClient.ClientId,
                ClientSecret = _clientSetting.MultiShopClient.ClientSecret,
                Address = discoveryDocument.TokenEndpoint
            };
            var newToken = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);
            await _clientAccessTokenCache.SetAsync("multishoptoken", newToken.AccessToken, newToken.ExpiresIn);
            return newToken.AccessToken;
        }
    }
}
