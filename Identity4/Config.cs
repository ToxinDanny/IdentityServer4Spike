﻿using System.Collections.Generic;
using IdentityServer4.Models;

namespace Identity4
{
    public class Config
    {
        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {

                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent = true,
                    RequirePkce = true,

                    // where to redirect to after login
                    RedirectUris = { "https://localhost:5011/signin-oidc" },
                    
                    // where to redirect to after logout
                    

                    PostLogoutRedirectUris = { "https://localhost:5011/signout-callback-oidc" },

                    AllowedScopes = {"openid","profile","email","address", "myApi"},

                    AccessTokenLifetime = 60

                    
                },

                new Client
                {
                    ClientId = "angular",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent = true,
                    RequirePkce = true,

                    // where to redirect to after login
                    RedirectUris = { "http://localhost:4200/signin-oidc"},
                    
                    // where to redirect to after logout
                    
                    PostLogoutRedirectUris = { "https://localhost:4200/signout-callback-oidc" },

                    AllowedCorsOrigins = {"http://localhost:4200"},

                    AllowedScopes = {"openid","profile","email","address", "myApi"},

                }

            };
        }

        //List of all information that we have to protect
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
                new IdentityResource()
                {
                    Name = "address",
                    DisplayName = "Address",
                    UserClaims = {"user_address"}
                },
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new ApiResource[]
            {
                new ApiResource("myApi")
            };
        }
    }
}
