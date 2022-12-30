using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class WhatIDo : IEntity
    {
        public int WhatIdoId { get; set; } 
        public string Title { get; set; }
        public int Sort { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string Image { get; set; } = "";
        public bool IsActive { get; set; }
    }
}
