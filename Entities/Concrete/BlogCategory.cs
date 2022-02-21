using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class BlogCategory : IEntity
    {
        public int BlogCategoryId { get; set; }
        public string CategoryNameTr { get; set; }
        public string CategoryNameEn { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
