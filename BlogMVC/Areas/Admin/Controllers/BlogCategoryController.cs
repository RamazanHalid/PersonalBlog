using Business.Abstract;
using Core.Utilities.Results;
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
        public IActionResult Add(int id)
        {
            if (id > 0)
            {
                var blogCategory = _blogCategoryService.GetById(id).Data;
                return View(blogCategory);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Add(BlogCategory blogCategory)
        {
            IResult result;
            if (blogCategory.BlogCategoryId > 0)
                result = _blogCategoryService.Update(blogCategory);
            else
                result = _blogCategoryService.Add(blogCategory);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            ViewData["Message"] = result.Message;
            return View();
        }
    }
}
