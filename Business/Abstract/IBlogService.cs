using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBlogService
    {
        IDataResult<List<Blog>> GetAll(int blogCategoryId, int IsActive);
        IDataResult<Blog> GetById(int id);
        IResult Add(Blog blog);
        IResult Update(Blog blog);
        IResult Delete(int id);
    }
}
