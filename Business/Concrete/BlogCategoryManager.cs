using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BlogCategoryManager : IBlogCategoryService
    {
        [SecuredOperation("yetki")]
        public IDataResult<List<BlogCategory>> GetAll()
        {
            return new SuccessDataResult<List<BlogCategory>>(new List<BlogCategory>
            {
                new BlogCategory
                {
                    BlogCategoryId = 1,
                    CategoryNameEn = "qwe",
                    CategoryNameTr = "ewq"
                },
                new BlogCategory
                {
                    BlogCategoryId = 2,
                    CategoryNameEn = "Ramazan",
                    CategoryNameTr = "Halid"
                }
            });
        }
    }
}
