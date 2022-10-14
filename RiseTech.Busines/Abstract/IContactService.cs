using RiseTech.Busines.ResultModels;
using RiseTech.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseTech.Busines.Abstract
{
    public interface IContactService
    {
        IDataResult<ContactDetailDto> GetContactDetail(Guid id);
        IResult AddContactInfo(ContactInfoDto contactInfo,Guid Id);
        IResult DeleteContactInfo(Guid Id);
        IResult AddContact(ContactDto Contact);
        IResult DeleteContact(Guid Id);
        IResult UpdateContact(ContactDto Contact , Guid Id);
        IDataResult<IList<Person>> GetContacts(int pagenumber, int size);
    }
}
