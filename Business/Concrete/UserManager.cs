using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private readonly int userId = 8;
        private readonly IMapper _mapper;
        public UserManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IDataResult<UpdateProfileDto> GetUserById()
        {
            var user = _userDal.Get(u => u.Id == userId);
            UpdateProfileDto updateProfileDto = _mapper.Map<UpdateProfileDto>(user);
            return new SuccessDataResult<UpdateProfileDto>(updateProfileDto, Messages.GetByIdSuccessfuly);
        }

        public IResult Update(UpdateProfileDto updateProfileDto)
        {
            var fullUser = _userDal.Get(u => u.Id == userId);
            User user = _mapper.Map<User>(updateProfileDto);
            user.Id = fullUser.Id;
            user.PasswordHash = fullUser.PasswordHash;
            user.PasswordSalt = fullUser.PasswordSalt;
            _userDal.Update(user);
            return new SuccessResult(Messages.UpdatedSuccessfuly);
        }

        public IDataResult<UserInfoForHeaderPage> GetUserInfo()
        {
            var users = _userDal.GetAll();
            List<UserInfoForHeaderPage> userInfoForHeaderPages = _mapper.Map<List<UserInfoForHeaderPage>>(users);
            return new SuccessDataResult<UserInfoForHeaderPage>(userInfoForHeaderPages.FirstOrDefault(), Messages.GetAllSuccessfuly);
        }
    }
}
