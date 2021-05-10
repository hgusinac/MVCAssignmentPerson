using MVCAssignmentPerson.Models.Service;
using MVCAssignmentPerson.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.Data
{
    public class CityService : ICityService

    {
        private readonly IPeopleRepo _peopleRepo;
        private readonly ICityRepo _cityRepo;
        private readonly ICountryRepo _countryRepo;

        public CityService(IPeopleRepo peopleRepo, ICityRepo cityRepo, ICountryRepo countryRepo)
        {
            _peopleRepo = peopleRepo;
           _cityRepo = cityRepo;
            _countryRepo = countryRepo;
        }
        public City Add(CreateCity CreateCity)
        {
            City city = new City();
            city.CityName = CreateCity.CityName;
            city.Country = _countryRepo.Read(CreateCity.CountryId);

            return _cityRepo.Create(city);
        }

        public List<City> All()
        {
            return _cityRepo.Read();
        }

        public City FindbyId(int id)
        {
            return _cityRepo.Read(id);
            
        }
        public City Edit(int id, CreateCity city)
        {
            City newcity = FindbyId(id);
            if (newcity == null)
            {
                return null;
            }
            newcity.CityName = city.CityName;
            newcity = _cityRepo.Update(newcity);

            return newcity;
        }


        public bool Remove(int id)
        {
            return _cityRepo.Delete(id);
        }
    }
}
