﻿using MVCAssignmentPerson.Models.Data;
using MVCAssignmentPerson.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCAssignmentPerson.Database;
using Microsoft.EntityFrameworkCore;
using MVCAssignmentPerson.Models.Repo;

namespace MVCAssignmentPerson.Database
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public DatabasePeopleRepo(PeopleDbContext peopleDbContext)
        {
           _peopleDbContext = peopleDbContext;
        }

        public Person Create(CreatePersonViewModel createPerson)
        {
            Person person = new Person();  // skapar en person 
            {
                person.Name = createPerson.Name; // överför datan från createPerson till Person. 
                person.InCityId = createPerson.CityId;
                person.Phone = createPerson.Phone;
            }
            
                                      

            _peopleDbContext.Add(person);// lägger till person med rätt namn city phone.

            int result = _peopleDbContext.SaveChanges();//sparar ändringar. 

            if (result == 0)
            {
                throw new Exception("Unable to add a Person to database");
            }
            return person;
        }



       
        public List<Person> Read()
        {
            
            return _peopleDbContext.People.Include("InCity").ToList(); // Ändrat så att InCity följer med personen.
        }
        public Person Read(int id)
        {
            return _peopleDbContext.People.Include(Person => Person.PersonLanguages)
                                          .ThenInclude(perLan => perLan.Language)
                                          .SingleOrDefault(row => row.Id == id);
        }

        public Person Update(Person person)
        {
            Person OriginalPerson = Read(person.Id);

            if (OriginalPerson == null)
            {
                return null;

            }

            OriginalPerson.Name = person.Name;
            OriginalPerson.Phone = person.Phone;
            OriginalPerson.InCityId = person.InCityId;

            int result = _peopleDbContext.SaveChanges(); // PROBLEM 

            if (result == 0)
            {

                return null; // PROBLEM
            }


            return OriginalPerson;
        }



        public bool Delete(int id)
        {

            //throw new NotImplementedException();
            Person person = Read(id);//hittar person med id
            if (person == null)
            {
                return false;
            }

            _peopleDbContext.Remove(person);// raderar personen 

            int result = _peopleDbContext.SaveChanges();// sparar förändringen

            if (result == 0)// om ingen förändring sker misslyckas raderingen.
            {
                return false;
            }

            return true;
        }
    }
}
