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

        public Person Create(CreatePersonViewModel createPerson)
        {
            Person person = new Person();// skapar en person 

            person.Name = createPerson.Name; // överför datan från createPerson till Person. 
            person.City = createPerson.City;
            person.Phone = createPerson.Phone;

            peopleDbContext.Add(person);// lägger till person med rätt namn city phone.
            int result = peopleDbContext.SaveChanges();//sparar ändringar. 

            if (result == 0)
            {
                throw new Exception("Unable to add a Person to database");
            }
            return person;
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
            Person OriginalPerson = Read(person.Id);

            if (OriginalPerson == null)
            {
                return null;

            }

            OriginalPerson.Name = person.Name;
            OriginalPerson.Phone = person.Phone;
            OriginalPerson.City = person.City;

            int result = peopleDbContext.SaveChanges();

            if (result == 0)
            {
                throw new Exception("Unable to add a Person to database");
            }


            return person;
        }



        public bool Delete(int id)
        {

            //throw new NotImplementedException();
            Person person = Read(id);//hittar person med id
            if (person == null)
            {
                return false;
            }

            peopleDbContext.Remove(person);// raderar personen 

            int result = peopleDbContext.SaveChanges();// sparar förändringen

            if (result == 0)// om ingen förändring sker misslyckas raderingen.
            {
                return false;
            }

            return true;
        }
    }
}
