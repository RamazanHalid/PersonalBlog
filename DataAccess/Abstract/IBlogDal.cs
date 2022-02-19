using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBlogDal : IEntityRepository<Blog>
    {

        List<Blog> GetAllWithInclude(Expression<Func<Blog, bool>> filter = null);
        Blog GetWithInclude(Expression<Func<Blog, bool>> filter);
    }
}
