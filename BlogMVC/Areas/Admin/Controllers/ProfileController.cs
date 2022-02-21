using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Helpers;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;



        public ProfileController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Update()
        {
            UpdateProfileDto updateProfileDto = _userService.GetUserById().Data;
            return View(updateProfileDto);
        }
        [HttpPost]
        public IActionResult Update(UpdateProfileDto updateProfileDto)
        {

            if (updateProfileDto.ProfileImageFile != null)
            {
                var w = FileHelper.Add(updateProfileDto.ProfileImageFile, "ProfileImages");
                updateProfileDto.ProfileImage = w.Data;
            }
            if (updateProfileDto.CvFile != null)
            {
                var e = FileHelper.Add(updateProfileDto.CvFile, "Cv");
                updateProfileDto.Cv = e.Data;
            }
            var result = _userService.Update(updateProfileDto);
            if (result.Success)
            {
                return RedirectToAction("Update");
            }
            return View(updateProfileDto);
        }
    }
}
