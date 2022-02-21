using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
namespace Business.Abstract
{
    public interface IContactService
    {
        IDataResult<List<Contact>> GetAll();
        IDataResult<Contact> GetById(int id);
        IResult Add(Contact contact);
        IResult Delete(int id);
    }
}
