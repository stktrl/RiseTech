using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseTech.Entities.Models
{
    public class ContactDetailDto
    {
        public ContactDetailDto()
        {
            ContactInfo = new List<ContactInfoDto>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public List<ContactInfoDto> ContactInfo { get; set; }
    }
}
