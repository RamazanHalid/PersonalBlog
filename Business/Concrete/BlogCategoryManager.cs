using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BlogCategoryManager : IBlogCategoryService
    {
        private readonly IBlogCategoryDal _blogCategoryDal;

        public BlogCategoryManager(IBlogCategoryDal blogCategoryDal)
        {
            _blogCategoryDal = blogCategoryDal;
        }

 
        public IDataResult<List<BlogCategory>> GetAll()
        {
            return new SuccessDataResult<List<BlogCategory>>(_blogCategoryDal.GetAll(), Messages.GetAllSuccessfuly);
        }

        public IDataResult<BlogCategory> GetById(int id)
        {
            return new SuccessDataResult<BlogCategory>(_blogCategoryDal.Get(b => b.BlogCategoryId == id), Messages.GetByIdSuccessfuly);
        }

        public IResult Update(BlogCategory blogCategory)
        {
            _blogCategoryDal.Update(blogCategory);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
        public IResult Add(BlogCategory blogCategory)
        {
            _blogCategoryDal.Add(blogCategory);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IResult Delete(int id)
        {
            var blogCategory = GetById(id).Data;
            _blogCategoryDal.Delete(blogCategory);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
    }
}
