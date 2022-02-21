using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IProjectService _projectService;

        public PortfolioController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public IActionResult Index()
        {
            var projectsResult = _projectService.GetAll(1);
            return View(projectsResult.Data);
        }
        public IActionResult ProjectDetails(int id)
        {
            var projectsResult = _projectService.GetById(id);
            return View(projectsResult.Data);
        }
    }
}
