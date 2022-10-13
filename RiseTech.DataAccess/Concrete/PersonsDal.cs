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
        public PersonsDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
