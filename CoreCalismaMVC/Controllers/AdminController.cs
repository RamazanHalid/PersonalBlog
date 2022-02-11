using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreCalismaMVC.Controllers
{
    public class AdminController : Controller
    {
        //private readonly IUserService _userService;
        //public AdminController(IUserService userService)
        //{
        //    _userService = userService;
        //}


        public IActionResult Index()
        {
            //var user = _userService.GetByMail("ramazan.halid.35@gmail.com");

            return View();
        }
    }
}
