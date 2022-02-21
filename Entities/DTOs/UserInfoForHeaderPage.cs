using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserInfoForHeaderPage : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string ProfileImage { get; set; }
        public string Cv { get; set; }
        public string AboutMeTr { get; set; }
        public string AboutMeEn { get; set; }
    }
}
