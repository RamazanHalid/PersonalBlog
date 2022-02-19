using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public IResult Add(Blog blog)
        {

            _blogDal.Add(blog);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IResult Delete(int id)
        {
            var blog = GetById(id).Data;
            _blogDal.Delete(blog);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IDataResult<List<Blog>> GetAll(int blogCategoryId, int IsActive)
        {
            List<Blog> blogs;
            if (IsActive == 0)
                blogs = _blogDal.GetAllWithInclude(b => blogCategoryId > 0 ? b.BlogCategory.BlogCategoryId == blogCategoryId : true
                && b.IsActive == false

                );
            else if (IsActive == 1)
                blogs = _blogDal.GetAllWithInclude(b => blogCategoryId > 0 ? b.BlogCategory.BlogCategoryId == blogCategoryId : true
                && b.IsActive == true
                );
            else
                blogs = _blogDal.GetAllWithInclude();
            return new SuccessDataResult<List<Blog>>(blogs, Messages.GetAllSuccessfuly);
        }

        public IDataResult<Blog> GetById(int id)
        {
            return new SuccessDataResult<Blog>(_blogDal.GetWithInclude(b => b.BlogId == id), Messages.GetByIdSuccessfuly);
        }

        public IResult Update(Blog blog)
        {

            _blogDal.Update(blog);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
