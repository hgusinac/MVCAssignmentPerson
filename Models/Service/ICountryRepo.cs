using MVCAssignmentPerson.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.Service
{
   public interface ICountryRepo
    {
        Country Create(Country country);
        Country Read(int id);
        List<Country> Read();
        Country Update(Country country);
        bool Delete(int id);
    }
}
