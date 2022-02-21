using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var blogsResult = _blogService.GetAll(-1, 1);
            return View(blogsResult.Data);
        }
        public IActionResult BlogDetails(int id)
        {
            var blogsResult = _blogService.GetById(id);
            return View(blogsResult.Data);
        }
    }
}
