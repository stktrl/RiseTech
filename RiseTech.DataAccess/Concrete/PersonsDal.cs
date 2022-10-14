using RiseTech.DataAccess.Abstract;
using RiseTech.DataAccess.Data;
using RiseTech.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseTech.DataAccess.Concrete
{
    public class PersonsDal : GenericRepository<Person>, IPersonsDal
    {
        private ApplicationDbContext _context;
        public PersonsDal(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Person GetPersonInfo(Guid Id)
        {
            return _context.Persons.Where(x => x.UUID == Id&&x.IsDeleted==false).Select(person => new Person
            {
                Company = person.Company,
                Surname = person.Surname,
                ContactInfos = person.ContactInfos,
                IsDeleted = person.IsDeleted,
                Name = person.Name,
                UUID = person.UUID,
            }).FirstOrDefault();

        }

      
    }
}
