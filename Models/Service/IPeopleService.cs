using MVCAssignmentPerson.Models.Data;
using MVCAssignmentPerson.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.Service

{
    public interface IPeopleService
    {
        //C
        public Person Add(CreatePersonViewModel createPerson);
        //R
        public PeopleViewModel All();

        public PeopleViewModel FindBy(PeopleViewModel search);
        public Person FindbyId(int id);
        //U
        public Person Edit(int id, CreatePersonViewModel createPerson);
        //D
        public bool Remove(int id);

    }
}
