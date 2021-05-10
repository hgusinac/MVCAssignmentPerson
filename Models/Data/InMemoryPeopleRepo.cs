
using MVCAssignmentPerson.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.Data

{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
         List<Person> PersonList = new List<Person>();
        int idCounter = 0;

     

        public Person Create(CreatePersonViewModel createPerson)
        {
            Person newPerson = new Person
            {
                Id = ++idCounter,
                Name = createPerson.Name,
                InCityId = createPerson.CityId,
                Phone = createPerson.Phone

            };
            PersonList.Add(newPerson);
            return newPerson;
        }


        public Person Read(int id)
        {
            return PersonList.SingleOrDefault(p => p.Id == id);// samma som if p.id==id
            
        }

        public List<Person> Read()
        {
            return PersonList;
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

            return OriginalPerson;

        }
      
        public bool Delete(int id)
        {
            Person OriginalPerson = Read(id);

            if (OriginalPerson == null)
            {
                return false;

            }
            return PersonList.Remove(OriginalPerson);

        }
        
        
    }
}
