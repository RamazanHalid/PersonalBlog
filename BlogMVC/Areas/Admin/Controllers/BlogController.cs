using AutoMapper;
using BlogMVC.Models;
using Business.Abstract;
using Core.Utilities.Helpers;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BlogMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IBlogCategoryService _blogCategoryService;
        private readonly IMapper _mapper;
        public BlogController(IBlogService blogService, IBlogCategoryService blogCategoryService = null, IMapper mapper = null)
        {
            _blogService = blogService;
            _blogCategoryService = blogCategoryService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var result = _blogService.GetAll(-1, -1);
            return View(result);
        }
        [HttpGet]
        public IActionResult Add(int id)
        {
            var categories = _blogCategoryService.GetAll().Data;
            List<SelectListItem> categoriesSelectList = (from x in categories
                                                         select new SelectListItem
                                                         {
                                                             Text = x.Title,
                                                             Value = x.BlogCategoryId.ToString()
                                                         }
                                                         ).ToList();

            ViewBag.blogCategories = categoriesSelectList;
            ViewBag.blogCategories2 = categories;
            if (id > 0)
            {

                Blog result = _blogService.GetById(id).Data;
                BlogWithImage blogWithImage = _mapper.Map<BlogWithImage>(result);
                return View(blogWithImage);
            }
            return View(new BlogWithImage());
        }
        [HttpPost]
        public IActionResult Add(BlogWithImage blogWithImage)
        {
            var categories = _blogCategoryService.GetAll().Data;
            List<SelectListItem> categoriesSelectList = (from x in categories
                                                         select new SelectListItem
                                                         {
                                                             Text = x.Title,
                                                             Value = x.BlogCategoryId.ToString()
                                                         }
                                                         ).ToList();

            ViewBag.blogCategories = categoriesSelectList;
            ViewBag.blogCategories2 = categories;

            if (blogWithImage.ImageFile != null)
            {
                var w = FileHelper.Add(blogWithImage.ImageFile, "BlogImages");
                blogWithImage.Image = w.Data;
            }
            Blog blog = _mapper.Map<Blog>(blogWithImage);
            if (blog.BlogId > 0)
            {
                var result = _blogService.Update(blog);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                ViewData["Message"] = result.Message;
                return View();
            }
            else
            {
                var result = _blogService.Add(blog);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                ViewData["Message"] = result.Message;
                return View();
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = _blogService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
