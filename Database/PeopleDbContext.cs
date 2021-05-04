using Microsoft.EntityFrameworkCore;
using MVCAssignmentPerson.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Database
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        { }
       
       public DbSet<Person> people { get; set; }
    }

        
}
