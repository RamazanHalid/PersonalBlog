using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IExperienceService
    {
        IDataResult<List<Experience>> GetAll(int isActive);
        IDataResult<Experience> GetById(int id);
        IResult Add(Experience experience);
        IResult Update(Experience experience);
        IResult Delete(int id);
    }
}
