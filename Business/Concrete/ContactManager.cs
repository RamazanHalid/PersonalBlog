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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _conrtactDal;

        public ContactManager(IContactDal conrtactDal)
        {
            _conrtactDal = conrtactDal;
        }

        public IResult Add(Contact contact)
        {
            _conrtactDal.Add(contact);
            return new SuccessResult(Messages.AddedSuccessfuly);
        }

        public IResult Delete(int id)
        {
            Contact contact = _conrtactDal.Get(c => c.ContactId == id);
            _conrtactDal.Delete(contact);
            return new SuccessResult(Messages.DeletedSuccessfuly);
        }

        public IDataResult<List<Contact>> GetAll()
        {
            return new SuccessDataResult<List<Contact>>(_conrtactDal.GetAll(), Messages.GetAllSuccessfuly);
        }

        public IDataResult<Contact> GetById(int id)
        {
            return new SuccessDataResult<Contact>(_conrtactDal.Get(c => c.ContactId == id));

        }
    }
}
