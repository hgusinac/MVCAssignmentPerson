using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.Data
{
    public class PersonLanguage // Join Table 
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }



        public int LanguageId { get; set; }
        public Language Language { get; set; }


    }
}
