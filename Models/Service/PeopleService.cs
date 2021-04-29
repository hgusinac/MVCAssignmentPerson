
using MVCAssignmentPerson.Models.Data;
using MVCAssignmentPerson.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.Service
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo _peopleRepo;

        public PeopleService()
        {
            _peopleRepo = new InMemoryPeopleRepo();
        }

        public Person Add(CreatePersonViewModel createPerson)
        {
           return _peopleRepo.Create(createPerson);
            
        }

        

        public PeopleViewModel All()
        {
            PeopleViewModel vm = new PeopleViewModel();
            vm.PeopleList = _peopleRepo.Read();

            return vm;
        }
        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            string filter = search.SearchPerson;
            search = this.All();
            List<Person> filteredList = new List<Person>();

            if (String.IsNullOrWhiteSpace(filter))
            {
                return search;
            }
            else
            {
                foreach (Person item in search.PeopleList)
                {
                    if (item.Name.Contains(filter) ||
                        
                        item.City.Contains(filter))

                    {
                        filteredList.Add(item);
                    }
                }
                search.PeopleList = filteredList;

                return search;
            }


        }


        public Person FindbyId(int id)
        {
            return _peopleRepo.Read(id);
        }
        

        public Person Edit(int id, CreatePersonViewModel createPerson)
        {
            Person person = FindbyId(id);

            if(person == null)
            {
                return null;
            }

            person.Id = id;
            person.Name = createPerson.Name;
            person.Phone = createPerson.Phone;
            person.City = createPerson.City;


           return _peopleRepo.Update(person);
        }
       

        public bool Remove(int id)
        {

            return _peopleRepo.Delete(id);

        }

    }
}
