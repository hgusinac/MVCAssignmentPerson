
using MVCAssignmentPerson.Models.Data;
using MVCAssignmentPerson.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCAssignmentPerson.Models.Repo;

namespace MVCAssignmentPerson.Models.Service
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo _peopleRepo;
        private readonly ICityRepo _cityRepo;

        public PeopleService(IPeopleRepo peopleRepo, ICityRepo cityRepo)
        {
            _peopleRepo = peopleRepo;
            _cityRepo = cityRepo;
        }

        public Person Add(CreatePersonViewModel createPerson)
        {
           return _peopleRepo.Create(createPerson);
            
        }

        

        public PeopleViewModel All()
        {
            PeopleViewModel vm = new PeopleViewModel();
            vm.PeopleList = _peopleRepo.Read();
            vm.CreatePersonViewModel.CityList = _cityRepo.Read();//Alla citys i listan. 

            return vm;
        }
        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            
            List<Person> filteredList = new List<Person>();
            search.CreatePersonViewModel.CityList = _cityRepo.Read(); // sökningen inte crashar
            if (String.IsNullOrWhiteSpace(search.SearchPerson))
            {
                search.PeopleList = _peopleRepo.Read();
                return search;
            }
            else
            {
                foreach (Person item in _peopleRepo.Read())
                {


                    if (item.Name.Contains(search.SearchPerson) ||

                        item.InCity != null && item.InCity.CityName.Contains(search.SearchPerson)) // null check. item.Incity !=null 

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
            person.InCityId = createPerson.CityId;


           return _peopleRepo.Update(person);
        }
       

        public bool Remove(int id)
        {

            return _peopleRepo.Delete(id);

        }

    }
}
