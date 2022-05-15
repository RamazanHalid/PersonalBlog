using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace BlogWebApi.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public AuthorizationController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(new UserForLoginDto
            {
                Email = "ramazan.halid.35@gmail.com",
                Password = "123123123123"
            });
        }
        [HttpPost]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var result = _authService.Login(userForLoginDto);
            if (!result.Success)
            {
                ViewData["Message"] = result.Message;
                return View();
            }
            //Create the identity for the user  
            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, result.Data.FirstName),
                    new Claim(ClaimTypes.NameIdentifier,result.Data.FirstName)
                }, CookieAuthenticationDefaults.AuthenticationScheme);
            var roles = _userService.GetClaims(result.Data);
            roles.ForEach(role => identity.AddClaim(new Claim(ClaimTypes.Role, role.Name)));
            var principal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return RedirectToAction("Index", "HomePage", new { area = "Admin" });

        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(UserForRegisterDto userForRegisterDto)
        {
            if (userForRegisterDto.Password != userForRegisterDto.PasswordConfirim)
            {
                ViewData["Message"] = "Passwords are not same!";
                return View();
            }
            if (!userForRegisterDto.DoesAgreeTermsAndPolicy)
            {
                ViewData["MessageForPolicy"] = "Please accepts Policies!";
                return View();
            }
            var result = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            if (!result.Success)
            {
                return View();
            }
            return RedirectToAction("Login");
        }

    }
}
