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
    public class EducationManager : IEducationService
    {
        private readonly IEducationDal _educationDal;
        public EducationManager(IEducationDal educationDal)
        {
            _educationDal = educationDal;
        }

        public IResult Add(Education education)
        {
            _educationDal.Add(education);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IResult Delete(int id)
        {
            Education education = _educationDal.Get(e => e.EducationId == id);
            _educationDal.Delete(education);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IDataResult<List<Education>> GetAll(int isActive)
        {
            List<Education> educations;
            if (isActive == 0)
                educations = _educationDal.GetAll(e => e.IsActive == false);
            else if (isActive == 1)
                educations = _educationDal.GetAll(e => e.IsActive == true);
            else
                educations = _educationDal.GetAll();
            return new SuccessDataResult<List<Education>>(educations, Messages.GetAllSuccessfuly);
        }

        public IDataResult<Education> GetById(int id)
        {
            return new SuccessDataResult<Education>(_educationDal.Get(e => e.EducationId == id), Messages.GetByIdSuccessfuly);
        }

        public IResult Update(Education education)
        {
            _educationDal.Update(education);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
