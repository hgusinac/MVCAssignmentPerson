using MVCAssignmentPerson.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.Service

{
   public interface IPersonLanguageService
    {
        PersonLanguage Add(PersonLanguage personLanguage);
        PersonLanguage Add(int personId, int langId);
        List<PersonLanguage> All();

        PersonLanguage FindbyId(int id, int personLanguageId);
        List<PersonLanguage> FindbyId(int id);

        bool Delete(int personId, int langId);
    }
}
