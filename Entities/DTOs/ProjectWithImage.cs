using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProjectWithImage : IDto
    {
        public int ProjectId { get; set; }
        public string ProjectNameTr { get; set; }
        public string ProjectNameEn { get; set; }
        public string ContentShortTr { get; set; }
        public string ContentShortEn { get; set; }
        public string ContentTr { get; set; }
        public string ContentEn { get; set; }
        public string Image { get; set; }
        public IFormFile ImageFile { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public string Technologies { get; set; }
        public bool IsActive { get; set; } = true;
        public int Sort { get; set; }
        public int ViewCount { get; set; }
    }
}
