using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Areas.Admin.ViewComponents
{
    public class AddBlogCategory : ViewComponent
    {
        private readonly IBlogCategoryService _blogCategoryService;

        public AddBlogCategory(IBlogCategoryService blogCategoryService)
        {
            _blogCategoryService = blogCategoryService;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
