using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.ViewComponents
{
    public class HomePageHeaderPart : ViewComponent
    {
        private readonly IUserService _userService;

        public HomePageHeaderPart(IUserService userService)
        {
            _userService = userService;
        }
        public IViewComponentResult Invoke()
        {
            var result = _userService.GetUserInfo().Data;
            return View(result);
        }
    }
}
