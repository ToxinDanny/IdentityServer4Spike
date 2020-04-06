// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServerAspNetIdentity
{
    public static class Config
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
                    RedirectUris = { UriConst.ClientMVCUri + "/signin-oidc" },
                    PostLogoutRedirectUris = { UriConst.ClientMVCUri + "/signout-callback-oidc" },
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
                    RedirectUris = { UriConst.ClientAngularUri + "/signin-callback" },
                    PostLogoutRedirectUris = { UriConst.ClientAngularUri + "/signout-callback" },
                    AllowedCorsOrigins = {UriConst.ClientAngularUri},
                    AllowedScopes = {"openid","profile","email","address", "myApi"},
                    AccessTokenLifetime = 3600,
                    Claims = new Claim[]
                    {
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim(JwtClaimTypes.Role, "user")
                    }
                },
                
                //new Client
                //{
                //    ClientId = "spa",
                //    ClientName = "SPA Client",
                //    ClientUri = "http://identityserver.io",

                //    AllowedGrantTypes = GrantTypes.Code,
                //    RequirePkce = true,
                //    RequireClientSecret = false,

                //    RedirectUris =
                //    {
                //        "http://localhost:5002/index.html",
                //        "http://localhost:5002/callback.html",
                //        "http://localhost:5002/silent.html",
                //        "http://localhost:5002/popup.html",
                //    },

                //    PostLogoutRedirectUris = { "http://localhost:5002/index.html" },
                //    AllowedCorsOrigins = { "http://localhost:5002" },

                //    AllowedScopes = { "openid", "profile", "api1" }
                //}
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
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new ApiResource[]
            {
                new ApiResource
                {
                    Name = "myApi",
                    Scopes = {new Scope("myApi")},
                    UserClaims = {JwtClaimTypes.Role}
                }
            };
        }
    }
}