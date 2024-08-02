﻿using System.Security.Claims;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MultiShop.DtoLayer.IdentityDtos;
using MultiShop.MvcUI.Services.Abstract;
using MultiShop.MvcUI.Settings;

namespace MultiShop.MvcUI.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly string _identityUrl;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClientSetting _clientSetting;

        public IdentityService(IOptions<ClientSetting> clientSetting, IHttpContextAccessor httpContextAccessor,IHttpClientFactory httpClientFactory)
        {
            _clientSetting = clientSetting.Value;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _identityUrl = configuration["IdentityUrl"]!;
            _httpClient = _httpClientFactory.CreateClient();
        }

        public async Task<bool> SignInAsync(SignInDto signInDto)
        {
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest()
            {
                Address = _identityUrl,
                Policy = new DiscoveryPolicy()
                {
                    RequireHttps = false
                }
            }); // get identityserver4 endpoints
            var paswordTokenRequest = new PasswordTokenRequest()
            { 
                ClientId = _clientSetting.MultiShopManagerClient.ClientId,
                ClientSecret = _clientSetting.MultiShopManagerClient.ClientSecret,
                UserName = signInDto.UserName,
                Password = signInDto.Password,
                Address = discoveryEndPoint.TokenEndpoint
            };

            var token = await _httpClient.RequestPasswordTokenAsync(paswordTokenRequest);

            var userInfoRequest = new UserInfoRequest()
            {
                Token = token.AccessToken,
                Address = discoveryEndPoint.UserInfoEndpoint
            };

            var userInfo = await _httpClient.GetUserInfoAsync(userInfoRequest); //get claims

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userInfo.Claims,
                CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authenticationProperties = new AuthenticationProperties();

            authenticationProperties.StoreTokens(new List<AuthenticationToken>()
            {
                new AuthenticationToken()
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = token.AccessToken
                },
                new AuthenticationToken()
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = token.RefreshToken
                },
                new AuthenticationToken()
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.UtcNow.AddMinutes(token.ExpiresIn).ToString()
                }
            });
            authenticationProperties.IsPersistent = false;
            
            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal, authenticationProperties);
            return true;
        }
    }
}
