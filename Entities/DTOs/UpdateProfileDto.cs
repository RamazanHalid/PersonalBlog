using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UpdateProfileDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string ProfileImage { get; set; }
        public IFormFile ProfileImageFile { get; set; }
        public string CellPhone { get; set; }
        public int CityId { get; set; }
        public string Email { get; set; }
        public string AboutMeTr { get; set; }
        public string AboutMeEn { get; set; }
        public string Cv { get; set; }
        public IFormFile CvFile { get; set; }
    }
}
