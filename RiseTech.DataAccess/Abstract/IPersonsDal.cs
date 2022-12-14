using RiseTech.DataAccess.Data;
using RiseTech.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseTech.DataAccess.Abstract
{
    public interface IPersonsDal:IGenericRepository<Person>
    {
        Person GetPersonInfo(Guid Id);

        List<Report> Report();
    }
}
