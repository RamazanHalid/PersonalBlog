using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBlogCategoryService
    {
        IDataResult<List<BlogCategory>> GetAll();
        IDataResult<BlogCategory> GetById(int id);
        IResult Add(BlogCategory blogCategory);
        IResult Update(BlogCategory blogCategory);
        IResult Delete(int id);
    }
}
