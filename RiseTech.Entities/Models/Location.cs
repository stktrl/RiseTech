using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseTech.Entities.Models
{
    public class Location
    {
        [Key]
        public int CityNumber { get; set; }
        public string CityName { get; set; }

    }
}
