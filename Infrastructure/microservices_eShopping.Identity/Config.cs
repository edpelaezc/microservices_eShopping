// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Collections;
using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityModel;

namespace microservices_eShopping.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("CatalogApi"),
                new ApiScope("BasketApi"),
                new ApiScope("CatalogApi.Read"),
                new ApiScope("CatalogApi.Write"),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                // list of microservices
                new ApiResource("Catalog", "Catalog.API")
                {
                    Scopes = {"CatalogApi"}
                },
                new ApiResource("Basket", "Basket.API")
                {
                    Scopes = {"BasketApi"}
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                //m2m flow
                new Client()
                {
                    ClientName = "Catalog API Client",
                    ClientId = "CatalogAPIClient",
                    ClientSecrets = {new Secret("e560086e-74b8-463b-bd76-525598f9414f".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"CatalogApi.Read", "CatalogApi.Write", "CatalogApi"}
                }
            };
    }
}