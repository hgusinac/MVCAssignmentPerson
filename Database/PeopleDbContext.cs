using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCAssignmentPerson.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Database
{
    public class PeopleDbContext : IdentityDbContext<IdentityUser>
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        { }

        // Join table Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //Recommend on the first line inside method.

            modelBuilder.Entity<PersonLanguage>().HasKey(pl =>
            new
            {
                pl.PersonId,
                pl.LanguageId
            });

            modelBuilder.Entity<PersonLanguage>()
           .HasOne<Person>(pl => pl.Person)
           .WithMany(p => p.PersonLanguages)
           .HasForeignKey(sc => sc.PersonId);


            modelBuilder.Entity<PersonLanguage>()
           .HasOne<Language>(pl => pl.Language)
           .WithMany(l => l.PersonLanguages)
           .HasForeignKey(pl => pl.LanguageId);
        }



        public DbSet<Person> People { get; set; }
        public DbSet<City> Cityis { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }//meny to meny
        public DbSet<PersonLanguage> PersonLanguages { get; set; }//meny to meny


    }


}
/*
 * dotnet ef migrations add
 * 
 * dotnet ef database update
 * 
 * 
 */
