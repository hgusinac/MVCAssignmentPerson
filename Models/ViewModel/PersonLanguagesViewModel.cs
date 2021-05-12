using MVCAssignmentPerson.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.ViewModel
{
    public class PersonLanguagesViewModel
    {
        public Person Person { get; set; }

        public List<Language> Languages { get; set; }


    }
}
