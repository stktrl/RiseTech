using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseTech.Entities.Models
{
    [Keyless]
    public class Report
    {
        public string Sehir { get; set; }
        public int KayitliKisi { get; set; }
        public int KayitliTelefonNumarasi { get; set; }

    }
}
