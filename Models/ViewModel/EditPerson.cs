using MVCAssignmentPerson.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.ViewModel
{
    public class EditPerson
    {
        public List<City> Citylist { get; set; }


        public int Id {set; get;}

        public CreatePersonViewModel CreatePerson { get; set; }

        public EditPerson(int id, Person person)
        {
            Id = id;
            this.CreatePerson = new CreatePersonViewModel() { Name = person.Name, CityId = person.InCityId, Phone = person.Phone };
        }

        public EditPerson(int id, CreatePersonViewModel createPerson)
        {
            Id = id;
            this.CreatePerson = createPerson;
        }


        
    }
}
