using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;

namespace BlogMVC.Models
{
    public class BlogWithImage
    {
        public int BlogId { get; set; }
        public string HeaderTr { get; set; }
        public string HeaderEn { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Image { get; set; }
        public int BlogCategoryId { get; set; }
        public virtual BlogCategory BlogCategory { get; set; }
        public string TextTr { get; set; }
        public string TextEn { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string KeyWords { get; set; }
        public bool IsActive { get; set; } = true;
        public int Sort { get; set; }
        public int ViewCount { get; set; }
    }
}
