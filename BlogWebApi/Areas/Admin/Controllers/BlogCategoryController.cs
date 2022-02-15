using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogCategoryController : Controller
    {
        private readonly IBlogCategoryService _blogCategoryService;

        public BlogCategoryController(IBlogCategoryService blogCategoryService)
        {
            _blogCategoryService = blogCategoryService;
        }

        public IActionResult Index()
        {
            var result = _blogCategoryService.GetAll();
            return View(result.Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(BlogCategory blogCategory)
        {
            var result = _blogCategoryService.Add(blogCategory);
            if (result.Success)
            {
                blogCategory = new BlogCategory();
                return RedirectToAction("Index");
            }
            ViewData["Message"] = result.Message;
            return View();
        }
    }
}
