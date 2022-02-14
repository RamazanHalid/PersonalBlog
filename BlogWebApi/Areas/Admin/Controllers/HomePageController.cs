using Microsoft.AspNetCore.Mvc;

namespace BlogWebApi.Areas.Admin.Controllers
{
    public class HomePageController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
