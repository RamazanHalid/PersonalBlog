using BlogMVC.Models;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Controllers
{
    public class ResumeController : Controller
    {
        private readonly IEducationService _educationService;
        private readonly IExperienceService _experienceService;

        public ResumeController(IEducationService educationService, IExperienceService experienceService)
        {
            _educationService = educationService;
            _experienceService = experienceService;
        }

        public IActionResult Index()
        {

            return View(new ResumeModel
            {
                Educations = _educationService.GetAll(1).Data,
                Experiences = _experienceService.GetAll(1).Data,
            });
        }
    }
}
