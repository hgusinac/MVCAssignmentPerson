using MVCAssignmentPerson.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.Service
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
