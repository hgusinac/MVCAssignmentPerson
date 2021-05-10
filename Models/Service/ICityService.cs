using MVCAssignmentPerson.Models.Data;
using MVCAssignmentPerson.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.Service
{
   public interface ICityService
    {

        City Add(CreateCity createCity);

        List<City> All();


        City FindbyId(int id);

        City Edit(int id, CreateCity city);

        bool Remove(int id);
    }
}
