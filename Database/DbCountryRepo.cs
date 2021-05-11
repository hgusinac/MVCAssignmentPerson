using MVCAssignmentPerson.Models.Data;
using MVCAssignmentPerson.Models.Repo;
using MVCAssignmentPerson.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Database
{
    public class DbCountryRepo : ICountryRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public DbCountryRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Country Create(Country country)
        {
            _peopleDbContext.Add(country);

            int result = _peopleDbContext.SaveChanges();

            if ( result == 0)
            {
                return null;
            }
            return country;
        }

       

        public Country Read(int id)
        {
            return _peopleDbContext.Countries.Find(id);
        }

        public List<Country> Read()
        {
            return _peopleDbContext.Countries.ToList();
        }

        public Country Update(Country country)
        {
            Country newCountry = Read(country.Id);
            if (newCountry == null)
            {
                return null;
            }
            _peopleDbContext.Update(country);

            int result = _peopleDbContext.SaveChanges();

            if (result == 0)
            {
                return null;
            }
            return country;
        }
        public bool Delete(int id)
        {
            Country newCountry = Read(id);
            if (newCountry == null)
            {
                return false;
            }
            _peopleDbContext.Countries.Remove(newCountry);

            int result = _peopleDbContext.SaveChanges();

            if (result == 0)
            {
                return false;
            }
            return true;
        }
    }
}
