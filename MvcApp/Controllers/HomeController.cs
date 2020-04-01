using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcApp.Models;
using Newtonsoft.Json.Linq;
using IdentityModel.Client;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return Challenge(new AuthenticationProperties
            {
                RedirectUri = "/Home/Index"
            }, "oidc");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }

        [HttpGet]
        public async Task<IActionResult> CallApi()
        {
            var client = new HttpClient();
            await RefreshTokenAsync(client);
            var accessToken = await HttpContext.GetTokenAsync("access_token");
           
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync("https://localhost:5001/api/WeatherForecast");

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return Unauthorized();
            }

            var result = await response.Content.ReadAsStringAsync();
            var model = new ApiResponseModel
            {
                Response = JArray.Parse(result)
            };
            return View(model);
        }

        private async Task RefreshTokenAsync(HttpClient Client)
        {            
            var discoveryDocument = await Client.GetDiscoveryDocumentAsync("https://localhost:5000/");

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");
            var identityToken = await HttpContext.GetTokenAsync("id_token");

            var tokenResponse = await Client.RequestRefreshTokenAsync(
                new RefreshTokenRequest
                {
                    Address = discoveryDocument.TokenEndpoint,
                    RefreshToken = refreshToken,
                    ClientId = "mvc",
                    ClientSecret = "secret",
                });

            var authInfo = await HttpContext.AuthenticateAsync("Cookies");

            authInfo.Properties.UpdateTokenValue("access_token", tokenResponse.AccessToken);
            authInfo.Properties.UpdateTokenValue("id_token", tokenResponse.IdentityToken);
            authInfo.Properties.UpdateTokenValue("refresh_token", tokenResponse.RefreshToken);

            await HttpContext.SignInAsync("Cookies", authInfo.Principal, authInfo.Properties);

        }
    }
}
