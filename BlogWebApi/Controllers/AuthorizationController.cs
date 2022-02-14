using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebApi.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IAuthService _authService;

        public AuthorizationController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
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
