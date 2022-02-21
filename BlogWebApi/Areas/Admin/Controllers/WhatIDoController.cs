using Business.Abstract;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WhatIDoController : Controller
    {
        private readonly IWhatIDoService _whatIDoService;

        public WhatIDoController(IWhatIDoService whatIDoService)
        {
            _whatIDoService = whatIDoService;
        }
        public IActionResult Index()
        {
            var whatIDoDtos = _whatIDoService.GetAll(-1);
            return View(whatIDoDtos.Data);
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            if (id > 0)
            {
                var whatIdDoDto = _whatIDoService.GetById(id).Data;
                return View(whatIdDoDto);
            }
            return View(new WhatIDoDto());
        }
        [HttpPost]
        public IActionResult Add(WhatIDoDto whatIDoDto)
        {
            IResult result;
            if (whatIDoDto.ImageFile != null)
            {
                var res = FileHelper.Add(whatIDoDto.ImageFile, "Images");
                whatIDoDto.Image = res.Data;
            }
            if (whatIDoDto.WhatIdoId > 0)
                result = _whatIDoService.Update(whatIDoDto);
            else
                result = _whatIDoService.Add(whatIDoDto);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            ViewData["Message"] = result.Message;
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = _whatIDoService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
