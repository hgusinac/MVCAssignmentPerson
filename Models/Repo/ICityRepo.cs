using MVCAssignmentPerson.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCAssignmentPerson.Models.Repo;

namespace MVCAssignmentPerson.Models.Repo

{
    public interface ICityRepo
    {
        City Create(City city);

        City Read(int id);

        List<City> Read();
        City Update(City city);

        bool Delete(int id);
    }
}
