using Microsoft.EntityFrameworkCore;
using RiseTech.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseTech.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
    }
}
