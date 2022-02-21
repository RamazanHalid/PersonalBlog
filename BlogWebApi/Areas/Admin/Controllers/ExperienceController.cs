using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExperienceController : Controller
    {
        private readonly IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public IActionResult Index()
        {
            var experienceResult = _experienceService.GetAll(-1);
            return View(experienceResult.Data);
        }
        [HttpGet]
        public IActionResult AddAndUpdate(int id)
        {
            if (id > 0)
            {
                var experienceResult = _experienceService.GetById(id);
                return View(experienceResult.Data);
            }
            return View(new Experience());
        }
        [HttpPost]
        public IActionResult AddAndUpdate(Experience experience)
        {
            if (experience.ExperienceId> 0)
            {
                var experienceUpdateResult = _experienceService.Update(experience);
                if (experienceUpdateResult.Success)
                    return RedirectToAction("Index");
                return View(experience);
            }
            var experienceAddResult = _experienceService.Add(experience);
            if (experienceAddResult.Success)
                return RedirectToAction("Index");
            return View(experience);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var deleteResult = _experienceService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
