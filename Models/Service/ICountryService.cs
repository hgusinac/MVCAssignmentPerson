using MVCAssignmentPerson.Models.Data;
using MVCAssignmentPerson.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.Service
{
    public interface ICountryService
    {

        Country Add(CreateCountry CreateCountry);

        List<Country> All();


        Country FindbyId(int id);

        Country Edit(int id, CreateCountry country);

        bool Remove(int id);
    }
}
