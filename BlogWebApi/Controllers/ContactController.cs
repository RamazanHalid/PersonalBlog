using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
