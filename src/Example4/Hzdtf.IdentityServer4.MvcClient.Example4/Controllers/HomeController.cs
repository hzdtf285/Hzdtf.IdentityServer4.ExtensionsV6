using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using IdentityModel.Client;
using Microsoft.Extensions.Options;
using Hzdtf.IdentityServer4.Client.Extensions;
using Hzdtf.Utility.Model.Return;
using Microsoft.Extensions.DependencyInjection;

namespace Hzdtf.IdentityServer4.MvcClient.Example4.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IOptions<AuthenticationCookieOidcOptions> cookieOidcOptions;

        public HomeController(IOptions<AuthenticationCookieOidcOptions> cookieOidcOptions)
        {
            this.cookieOidcOptions = cookieOidcOptions;
        }

        public async Task<IActionResult> Index()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var httpClient = new HttpClient();
            httpClient.SetBearerToken(token);
            var url = "http://localhost:5006/servicea/api/values";

            var response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                return Content(content);
            }
            else
            {
                return Content(response.StatusCode.ToString());
            }
        }

        public IActionResult Logout()
        {
            return SignOut(cookieOidcOptions.Value.Scheme, "oidc");
        }
    }
}
