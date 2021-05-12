using MVCAssignmentPerson.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.Repo
{
   public interface IPersonLanguageRepo


    {
        PersonLanguage Create(PersonLanguage personLanguage);

        PersonLanguage Read(int personId, int langId);
        List<PersonLanguage> Read();

        bool Delete(int personId, int langId);
    }
}
