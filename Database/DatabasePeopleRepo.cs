using MVCAssignmentPerson.Models.Data;
using MVCAssignmentPerson.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCAssignmentPerson.Database;
namespace MVCAssignmentPerson.Database
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private readonly PeopleDbContext peopleDbContext;

        public DatabasePeopleRepo(PeopleDbContext peopleDbContext)
        {
            this.peopleDbContext = peopleDbContext;
        }

        public Person Create(CreatePersonViewModel createPerson)//Denna krånglar----CreatePersonViewModel createPerson)
        {
            Person person = new Person();
            peopleDbContext.Add(person);
            int result = peopleDbContext.SaveChanges();

            if(result == 0)
            {
                throw new Exception("Unable to add a Person to database");
            }
            return person;
        }

     

        public bool Delete(int id)
        {

            //throw new NotImplementedException();

            peopleDbContext.Remove(id);
            if(this.Read(id) == null)
            {
                return true;
            }
            return false;
        }
        public Person Read(int id)
        {
           return peopleDbContext.people.SingleOrDefault(row => row.Id == id);
        }

        public List<Person> Read()
        {
            return peopleDbContext.people.ToList();
        }


        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
