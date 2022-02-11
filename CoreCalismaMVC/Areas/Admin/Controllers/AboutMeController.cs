using Microsoft.AspNetCore.Mvc;

namespace CoreCalismaMVC.Areas.Admin.Controllers
{
    public class AboutMeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
