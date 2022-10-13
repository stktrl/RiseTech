using RiseTech.Busines.Abstract;
using RiseTech.Busines.ResultModels;
using RiseTech.DataAccess.Abstract;
using RiseTech.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseTech.Busines.Concrete
{
    public class ContactService : IContactService
    {
        private readonly IPersonsDal _personDal;
        private readonly IContactsDal _contactsDal;
        public ContactService(IPersonsDal personDal, IContactsDal contactsDal)
        {
            _personDal = personDal;
            _contactsDal = contactsDal;
        }

        public IResult AddContact(ContactDto Contact)
        {
            //mapping
            var tempPerson = new Person()
            {
                UUID = new Guid(),
                Surname = Contact.Surname,
                Name = Contact.Name,
                Company = Contact.Company,
                IsDeleted = false
            };
            _personDal.Add(tempPerson);
            //if (Contact.ContactInfo!=null)
            //{
            //    foreach (var item in Contact.ContactInfo)
            //    {
            //        var tempContactInfo = new ContactInfo()
            //        {
            //            Content = item.Content,
            //            InformationType = item.InformationType,
            //            UUID = new Guid(),
            //            Person= tempPerson,
            //            IsDeleted=false
            //        };
            //        _contactsDal.Add(tempContactInfo);
            //    }
            //}

            return new SuccessResult("Contact successfully Added.");
        }

        public IResult AddContactInfo(ContactInfoDto contactInfo,Guid Id)
        {
            var tempPerson = _personDal.Get(person => person.UUID == Id);
            var tempContactInfo = new ContactInfo()
            {
                Content = contactInfo.Content,
                InformationType = contactInfo.InformationType,
                UUID = new Guid(),
                Person = tempPerson,
                IsDeleted = false
            };
            _contactsDal.Add(tempContactInfo);
            return new SuccessResult("ContactInfo successfuly added.");
        }

        public IResult DeleteContact(Guid Id)
        {
            var tempEntity = _personDal.Get(entity => entity.UUID == Id);
            if (tempEntity == null)
            {
                return new ErrorResult("Contact not found", 404);
            }
            tempEntity.IsDeleted = true;
            _personDal.Update(tempEntity);
            return new SuccessResult("Contact successfuly deleted");
        }

        public IResult DeleteContactInfo(Guid Id)
        {
            var contactInfo = _contactsDal.Get(info => info.UUID == Id);
            contactInfo.IsDeleted = true;
            _contactsDal.Update(contactInfo);
            return new SuccessResult("Contact info successfuly deleted.");
        }

        public IDataResult<IList<Person>> GetContacts(int pagenumber, int size)
        {
            var result = _personDal.Pagination(pagenumber, size);
            return new SuccessDataResult<IList<Person>>(result);
        }

        public IResult UpdateContact(ContactDto Contact, Guid Id)
        {
            var tempPerson = _personDal.Get(entity => entity.UUID == Id);
            tempPerson.Surname = Contact.Surname;
            tempPerson.Name = Contact.Name;
            tempPerson.Company = Contact.Company;
            _personDal.Update(tempPerson);

            return new SuccessResult("Contact successfuly updated.");
        }
    }
}
