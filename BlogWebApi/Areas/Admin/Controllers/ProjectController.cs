using Business.Abstract;
using Core.Utilities.Helpers;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public IActionResult Index()
        {
            List<ProjectWithImage> projectWithImages = _projectService.GetAll(-1).Data;
            return View(projectWithImages);
        }
        [HttpGet]
        public IActionResult AddAndUpdate(int id)
        {
            if (id > 0)
            {
                var result = _projectService.GetById(id);
                return View(result.Data);
            }
            return View(new ProjectWithImage());
        }
        [HttpPost]
        public IActionResult AddAndUpdate(ProjectWithImage projectWithImage)
        {
            if (projectWithImage.ImageFile != null)
            {
                projectWithImage.Image = FileHelper.Add(projectWithImage.ImageFile, "ProjectImages").Data;
            }
            if (projectWithImage.ProjectId > 0)
            {
                var updateResult = _projectService.Update(projectWithImage);
                if (updateResult.Success)
                {
                    return RedirectToAction("Index");
                }
                return View(projectWithImage);
            }
            var addResult = _projectService.Add(projectWithImage);
            if (addResult.Success)
            {
                return RedirectToAction("Index");
            }
            return View(projectWithImage);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
