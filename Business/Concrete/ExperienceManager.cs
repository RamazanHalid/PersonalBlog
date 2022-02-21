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
    public class ExperienceManager : IExperienceService
    {
        private readonly IExperienceDal _experienceDal;
        public ExperienceManager(IExperienceDal experienceDal)
        {
            _experienceDal = experienceDal;
        }

        public IResult Add(Experience experience)
        {
            _experienceDal.Add(experience);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IResult Delete(int id)
        {
            var experience = _experienceDal.Get(x => x.ExperienceId == id);
            _experienceDal.Delete(experience);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IDataResult<List<Experience>> GetAll(int isActive)
        {
            List<Experience> experiences;
            if (isActive == 0)
                experiences = _experienceDal.GetAll(x => x.IsActive == false);
            else if (isActive == 1)
                experiences = _experienceDal.GetAll(x => x.IsActive == true);
            else
                experiences = _experienceDal.GetAll();
            return new SuccessDataResult<List<Experience>>(experiences, Messages.GetAllSuccessfuly);

        }


        public IDataResult<Experience> GetById(int id)
        {
            return new SuccessDataResult<Experience>(_experienceDal.Get(x => x.ExperienceId == id), Messages.GetByIdSuccessfuly);
        }

        public IResult Update(Experience experience)
        {
            _experienceDal.Update(experience);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
    }
}
