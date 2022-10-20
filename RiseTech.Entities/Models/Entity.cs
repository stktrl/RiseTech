﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseTech.Entities.Models
{
    public class Entity
    {
        [Key]
        public Guid UUID { get; set; }
        public bool  IsDeleted { get; set; }
    }
}
