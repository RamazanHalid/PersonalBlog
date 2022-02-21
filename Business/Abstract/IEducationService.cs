using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEducationService
    {
        IDataResult<List<Education>> GetAll(int isActive);
        IDataResult<Education> GetById(int id);
        IResult Add(Education education);
        IResult Update(Education education);
        IResult Delete(int id);
    }
}
