using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBlogDal : EfEntityRepositoryBase<Blog, PersonalBlogContext>, IBlogDal
    {
        public List<Blog> GetAllWithInclude(Expression<Func<Blog, bool>> filter = null)
        {
            using (var context = new PersonalBlogContext())
            {
                return filter == null
                    ? context.Set<Blog>().Include(b => b.BlogCategory).ToList()
                    : context.Set<Blog>().Include(b => b.BlogCategory).Where(filter).ToList();
            }
        }

        public Blog GetWithInclude(Expression<Func<Blog, bool>> filter)
        {
            using (var context = new PersonalBlogContext())
            {
                return context.Set<Blog>().Include(b => b.BlogCategory).SingleOrDefault(filter);
            }
        }
    }
}
