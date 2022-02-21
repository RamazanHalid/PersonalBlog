using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProjectManager : IProjectService
    {
        private readonly IProjectDal _projectDal;
        private readonly IMapper _mapper;
        public ProjectManager(IProjectDal projectDal, IMapper mapper)
        {
            _projectDal = projectDal;
            _mapper = mapper;
        }
        public IDataResult<List<ProjectWithImage>> GetAll(int isActive)
        {
            List<Project> projects;
            if (isActive == 0)
                projects = _projectDal.GetAll(p => p.IsActive == false);
            else if (isActive == 1)
                projects = _projectDal.GetAll(p => p.IsActive == true);
            else
                projects = _projectDal.GetAll();
            List<ProjectWithImage> projectWithImages = _mapper.Map<List<ProjectWithImage>>(projects);
            return new SuccessDataResult<List<ProjectWithImage>>(projectWithImages, Messages.GetAllSuccessfuly);
        }
        public IDataResult<ProjectWithImage> GetById(int id)
        {
            Project project = _projectDal.Get(p => p.ProjectId == id);
            ProjectWithImage projectWithImage = _mapper.Map<ProjectWithImage>(project);
            return new SuccessDataResult<ProjectWithImage>(projectWithImage, Messages.GetByIdSuccessfuly);
        }
        public IResult Add(ProjectWithImage projectWithImage)
        {
            Project project = _mapper.Map<Project>(projectWithImage);

            _projectDal.Add(project);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }
        public IResult Update(ProjectWithImage projectWithImage)
        {
            Project project = _mapper.Map<Project>(projectWithImage);
            _projectDal.Update(project);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }
        public IResult Delete(int id)
        {
            Project project = _projectDal.Get(p => p.ProjectId == id);
            _projectDal.Delete(project);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }
    }
}
