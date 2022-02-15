using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Areas.Admin.ViewComponents
{
    public class UserInfo : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
