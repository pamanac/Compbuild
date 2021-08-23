using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Compbuild.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Compbuild.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() //Individual action methods used in routing
        {
            return View(); //Return Views::Home::Index.cshtml
        }

        public IActionResult Privacy()
        {
            return View(); //Return Views::Home::Privacy.cshtml
        }

        [HttpGet("denied")]
        public IActionResult Denied(){
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Secured(){
            return View();
        }

        [HttpGet("login")] //This prevents default routing to home/login to /login
        public IActionResult Login(string returnUrl){
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Validate(string username, string password, string returnUrl){
            ViewData["ReturnUrl"] = returnUrl;
            if(username=="bob" && password=="pizza"){
                var claims = new List<Claim>();
                claims.Add(new Claim("username", username));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
                claims.Add(new Claim(ClaimTypes.Name, "Bob Ed Jones"));
                //claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                var ClaimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(ClaimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return Redirect(returnUrl);
            }
            TempData[
                "Error"
            ] = "Error. Username or Password is invalid";
            return View("login");
        }

        [Authorize] //you need to be logged-in to be able to log out
        public async Task<IActionResult> Logout(){
            await HttpContext.SignOutAsync();
            return Redirect("/"); //home page
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
