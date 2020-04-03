using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4.Models;
using IdentityModel;

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
                    RedirectUris = { "https://localhost:5011/signin-oidc" },
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
                    RedirectUris = { "http://localhost:4200/signin-callback"},
                    PostLogoutRedirectUris = { "http://localhost:4200/signout-callback" },
                    AllowedCorsOrigins = {"http://localhost:4200"},
                    AllowedScopes = {"openid","profile","email","address", "myApi"},
                    AccessTokenLifetime = 3600,
                    Claims = new Claim[]
                    {
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim(JwtClaimTypes.Role, "user")
                    }
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
