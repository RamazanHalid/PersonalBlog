using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Areas.Admin.ViewComponents
{
    public class UserInfo : ViewComponent
    {
        private readonly IUserService _userService;

        public UserInfo(IUserService userService)
        {
            _userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _userService.GetByMail("ramazan.halid.35@gmail.com");
            return View(result);
        }
    }
}
