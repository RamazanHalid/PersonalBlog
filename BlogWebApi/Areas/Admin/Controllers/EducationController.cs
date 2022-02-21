using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EducationController : Controller
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }
        public IActionResult Index()
        {
            var educationsResult = _educationService.GetAll(-1);
            return View(educationsResult.Data);
        }
        [HttpGet]
        public IActionResult AddAndUpdate(int id)
        {
            if (id > 0)
            {
                var educationResult = _educationService.GetById(id);
                return View(educationResult.Data);
            }
            return View(new Education());
        }
        [HttpPost]
        public IActionResult AddAndUpdate(Education education)
        {
            if (education.EducationId > 0)
            {
                var educationUpdateResult = _educationService.Update(education);
                if (educationUpdateResult.Success)
                    return RedirectToAction("Index");
                return View(education);
            }
            var educationAddResult = _educationService.Add(education);
            if (educationAddResult.Success)
                return RedirectToAction("Index");
            return View(education);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var deleteResult = _educationService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
