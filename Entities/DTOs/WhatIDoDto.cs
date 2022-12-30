using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class WhatIDoDto : IDto
    {
        public int WhatIdoId { get; set; }
        public string Title { get; set; }
        public int Sort { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string Image { get; set; } = "";
        public IFormFile ImageFile { get; set; }
        public bool IsActive { get; set; }
    }
}
