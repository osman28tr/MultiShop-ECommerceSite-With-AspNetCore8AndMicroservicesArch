﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
	public static class Config
	{
		public static IEnumerable<ApiResource> ApiResources = new ApiResource[]
		{
			new ApiResource("MultiShopCatalog") { Scopes = { "CatalogFullPermission", "CatalogReadPermission" } },
			new ApiResource("MultiShopDiscount"){Scopes = {"DiscountFullPermission","DiscountReadPermission"}},
			new ApiResource("MultiShopOrder"){Scopes = {"OrderFullPermission"}},
			new ApiResource(IdentityServerConstants.LocalApi.ScopeName), // Diğer mikroservisler dışında bir de identity için de kapsam oluşturuyoruz yani identity'e erişim yetkisi veriyoruz.
            new ApiResource("MultiShopCargo"){Scopes = {"CargoFullPermission","CargoReadPermission"}},
			new ApiResource("MultiShopBasket"){Scopes = { "BasketFullPermission"}},
            new ApiResource("MultiShopComment"){Scopes = { "CommentReadPermission","CommentFullPermission"}},
			new ApiResource("MultiShopPayment"){Scopes = {"PaymentFullPermission"}},
            new ApiResource("ResourceOcelot"){Scopes = { "OcelotFullPermission"}}
		};

		public static IEnumerable<IdentityResource> IdentityResources = new IdentityResource[]
			{ new IdentityResources.OpenId(), new IdentityResources.Email(), new IdentityResources.Profile() };

		public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
		{
			new ApiScope("CatalogFullPermission", "Full authority for catalog operations"),
			new ApiScope("CatalogReadPermission", "Read authority for catalog operations"),
			new ApiScope("DiscountFullPermission", "Full authority for discount operations"),
			new ApiScope("DiscountReadPermission", "Read authority for discount operations"),
			new ApiScope("OrderFullPermission", "Full authority for catalog operations"),
			new ApiScope("CargoReadPermission", "Read authority for cargo operations"),
			new ApiScope("CargoFullPermission","Full authority for cargo operations"),
			new ApiScope("BasketFullPermission","Full authority for basket operations"),
			new ApiScope("CommentReadPermission","Full authority for comment operations"),
			new ApiScope("CommentFullPermission","Full authority for comment operations"),
			new ApiScope("PaymentFullPermission","Full authority for payment operations"),
			new ApiScope("OcelotFullPermission","Full authority for ocelot operations"),
			new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
		};

		public static IEnumerable<Client> Clients => new Client[]
		{
			new Client()
			{
				ClientId = "MultiShopId",
				ClientName = "MultiShopMvc",
				AllowedGrantTypes = GrantTypes.ClientCredentials,
				ClientSecrets = {new Secret("multishopsecret".Sha256())},
				AllowedScopes = { "CatalogFullPermission","CargoReadPermission","OcelotFullPermission","CommentFullPermission" }
			},
			new Client()
			{
				ClientId = "MultiShopManagerId",
				ClientName = "MultiShopManager",
				AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
				ClientSecrets = {new Secret("multishopsecret".Sha256())},
				AllowedScopes = { "CatalogFullPermission","CargoReadPermission", "BasketFullPermission","DiscountFullPermission","CommentFullPermission","OrderFullPermission","PaymentFullPermission", "OcelotFullPermission", IdentityServerConstants.LocalApi.ScopeName, IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile }
			},
			new Client()
			{
				ClientId = "MultiShopAdminId",
				ClientName = "MultiShopAdmin",
				AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
				ClientSecrets = {new Secret("multishopsecret".Sha256())},
				AllowedScopes =
				{
					"CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission","CargoFullPermission","BasketFullPermission","CommentFullPermission","PaymentFullPermission","OcelotFullPermission", IdentityServerConstants.LocalApi.ScopeName, IdentityServerConstants.StandardScopes.Email,IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile
				},
				AccessTokenLifetime = 600
			}
		};
	}
}