using MVCAssignmentPerson.Models.Data;
using MVCAssignmentPerson.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVCAssignmentPerson.Database
{
    public class DbCityRepo : ICityRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public DbCityRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public City Create(City city)
        {
            _peopleDbContext.Add(city);
            int result = _peopleDbContext.SaveChanges();

            if(result == 0)
            {
                return null;
            }
            return city;
        }

        

        public City Read(int id)
        {
            return _peopleDbContext.Cityis.Find(id);
        }

        public List<City> Read()
        {
            return _peopleDbContext.Cityis.ToList();
        }
        public City Update(City city)
        {
            City newCity = Read(city.Id);

            if(newCity == null)
            {
                return null;
            }

            _peopleDbContext.Update(city);
           int result= _peopleDbContext.SaveChanges();


            if(result == 0)
            {
                return null;
            }
            return city;
        }
        public bool Delete(int id)
        {
            City newCity = Read(id);

            if (newCity == null)
            {
                return false;
            }
            _peopleDbContext.Cityis.Remove(newCity);
            int result = _peopleDbContext.SaveChanges();
            if (result == 0)
            {
                return false;
            }
            return true;

        }

       
    }
}
