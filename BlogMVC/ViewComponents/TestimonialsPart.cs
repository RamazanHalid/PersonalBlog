using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.ViewComponents
{
    public class TestimonialsPart : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
