using RiseTech.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseTech.Entities.Models
{
    public class ContactInfo:IEntity
    {
        [Key]
        public Guid UUID { get; set; }
        public virtual Person Person { get; set; }
        //public Guid PeopleId { get; set; }
        public InformationType InformationType { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
    }
}
