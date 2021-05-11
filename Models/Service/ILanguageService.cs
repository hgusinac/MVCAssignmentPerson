using MVCAssignmentPerson.Models.Data;
using MVCAssignmentPerson.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.Service
{
   public interface ILanguageService
    {
        Language Add(CreateLanguage CreateLanguage);

        List<Language> All();

        Language FindbyId(int id);

        Language Edit(int id, CreateLanguage language);

        bool Remove(int id);
    }
}
