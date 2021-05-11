using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.Data
{
  public  interface ILanguageRepo
    {
        public Language Create(Language language);

        public List<Language> Read();

        public Language Read(int id);

        public Language Update(Language language);


        public bool Delete(int id);
    }
}
