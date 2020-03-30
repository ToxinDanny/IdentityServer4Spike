using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Test;

namespace Identity4.TEST
{
    public class TestUsers
    {
        public static List<TestUser> Users = new List<TestUser>()
        {
            new TestUser()
            {
                SubjectId = "1000",
                Username = "test",
                IsActive = true,
                Password = "test",
                Claims = new List<Claim>()
                {
                    new Claim(JwtClaimTypes.Name, "Michele Marinelli"),
                    new Claim(JwtClaimTypes.GivenName, "Marinelli"),
                    new Claim(JwtClaimTypes.FamilyName, "Michele"),
                    new Claim(JwtClaimTypes.Email, "michele.marinelli@unikey.it"),
                    new Claim(JwtClaimTypes.EmailVerified, "true"),
                    new Claim(JwtClaimTypes.WebSite, "www-google.it"),
                    new Claim("user_address","Via di sto cazzo"),

                }

            },
            new TestUser()
            {
                SubjectId = "1001",
                Username = "michele.marinelli1@unikey.it",
                IsActive = true,
                Password = "test",
                Claims = new List<Claim>()
                {
                    new Claim(JwtClaimTypes.Name, "Michele Marinelli"),
                    new Claim(JwtClaimTypes.GivenName, "Marinelli"),
                    new Claim(JwtClaimTypes.FamilyName, "Michele"),
                    new Claim(JwtClaimTypes.Email, "michele.marinelli@unikey.it"),
                    new Claim(JwtClaimTypes.EmailVerified, "true"),
                    new Claim(JwtClaimTypes.WebSite, "www-google.it"),
                    new Claim("user_address","Via di sto cazzo"),

                }
            },
            new TestUser()
            {
                SubjectId = "1002",
                Username = "michele.marinelli2@unikey.it",
                IsActive = true,
                Password = "test",
                Claims = new List<Claim>()
                {
                    new Claim(JwtClaimTypes.Name, "Michele Marinelli"),
                    new Claim(JwtClaimTypes.GivenName, "Marinelli"),
                    new Claim(JwtClaimTypes.FamilyName, "Michele"),
                    new Claim(JwtClaimTypes.Email, "michele.marinelli@unikey.it"),
                    new Claim(JwtClaimTypes.EmailVerified, "true"),
                    new Claim(JwtClaimTypes.WebSite, "www-google.it"),
                    new Claim("user_address","Via di sto cazzo"),

                }
            }
        };

    }
}
    

