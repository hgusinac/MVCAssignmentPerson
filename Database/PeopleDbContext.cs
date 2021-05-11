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

        // Join table Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonLanguage>().HasKey(pl =>
            new
            {
                pl.PersonId,
                pl.LanguageId
            });

        }
    // modelBuilder.Entity<StudentCourse>()
    //.HasOne<Student>(sc => sc.Student)
    //.WithMany(s => s.StudentCourses)
    //.HasForeignKey(sc => sc.SId);


    // modelBuilder.Entity<StudentCourse>()
    //.HasOne<Course>(sc => sc.Course)
    //.WithMany(s => s.StudentCourses)
    //.HasForeignKey(sc => sc.CId);



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
