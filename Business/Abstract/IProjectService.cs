using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProjectService
    {
        IDataResult<List<ProjectWithImage>> GetAll(int isActive);
        IDataResult<ProjectWithImage> GetById(int id);
        IResult Add(ProjectWithImage projectWithImage);
        IResult Update(ProjectWithImage projectWithImage);
        IResult Delete(int id);
    }
}
