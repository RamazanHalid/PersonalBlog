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
        public string HeaderTr { get; set; }
        public string HeaderEn { get; set; }
        public int Sort { get; set; }
        public string ContentSummaryTr { get; set; }
        public string ContentSummaryEn { get; set; }
        public string ContentTr { get; set; }
        public string ContentEn { get; set; }
        public string Image { get; set; } = "";
        public IFormFile ImageFile { get; set; }
        public bool IsActive { get; set; }
    }
}
