using MVCAssignmentPerson.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCAssignmentPerson.Models.Repo;

namespace MVCAssignmentPerson.Models.Repo
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
