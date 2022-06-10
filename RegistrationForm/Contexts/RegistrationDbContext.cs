using Microsoft.EntityFrameworkCore;
using RegistrationForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationForm.Contexts
{
    public class RegistrationDbContext:DbContext
    {
        public RegistrationDbContext(DbContextOptions<RegistrationDbContext>dbContextOptions):base(dbContextOptions)
        {

        }


        public DbSet<Country> country { get; set; }

        public DbSet<Registration> registration { get; set; }
    }
}
