using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        IResult Update(UpdateProfileDto updateProfileDto);
        User GetByMail(string email);
        IDataResult<UpdateProfileDto> GetUserById();
        IDataResult<UserInfoForHeaderPage> GetAllUsers();
    }
}
