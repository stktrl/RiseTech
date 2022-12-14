using RiseTech.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseTech.Entities.Models
{
    public class Person:Entity
    {
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public virtual List<ContactInfo> ContactInfos { get; set; }
    }
}
