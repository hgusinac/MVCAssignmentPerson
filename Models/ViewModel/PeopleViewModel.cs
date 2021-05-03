using MVCAssignmentPerson.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.ViewModel
{
    public class PeopleViewModel
    {
        public PeopleViewModel()
        {
            CreatePersonViewModel = new CreatePersonViewModel();
            PeopleList = new List<Person>();
        }

        public List<Person> PeopleList { get; set; }

        public string SearchPerson { get; set; }


        public CreatePersonViewModel CreatePersonViewModel { get; set; }

      





    }
}
