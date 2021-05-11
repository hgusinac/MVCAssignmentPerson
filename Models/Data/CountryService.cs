using MVCAssignmentPerson.Models.Service;
using MVCAssignmentPerson.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCAssignmentPerson.Models.Repo;

namespace MVCAssignmentPerson.Models.Data
{
    public class CountryService : ICountryService

    {
        private readonly ICountryRepo _countryRepo;
        private readonly ICityRepo _cityRepo;

        public CountryService(ICountryRepo countryRepo, ICityRepo cityRepo)
        {
            _countryRepo = countryRepo;
            _cityRepo = cityRepo;
        }
        public Country Add(CreateCountry CreateCountry)
        {
            Country country = new Country();
            country.CountryName = CreateCountry.CountryName;

            return _countryRepo.Create(country);
        }

        public List<Country> All()
        {
            return _countryRepo.Read();
        }

        public Country FindbyId(int id)
        {
            return _countryRepo.Read(id);
        }
        public Country Edit(int id, CreateCountry country)
        {
            Country newCountry = FindbyId(id);
            if (newCountry == null)
            {
                return null;
            }
            newCountry.CountryName = country.CountryName;
            newCountry = _countryRepo.Update(newCountry);

            return newCountry;
        }


        public bool Remove(int id)
        {
            return _countryRepo.Delete(id);
        }
    }
}
