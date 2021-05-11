using MVCAssignmentPerson.Models.Data;
using MVCAssignmentPerson.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.Repo

{
   public interface IPeopleRepo
    {
        //CRUD
        public Person Create(CreatePersonViewModel createPerson);

        public List<Person> Read();

        public Person Read(int id);

        public Person Update(Person person);


        public bool Delete(int id);

    }
}
