using MVCAssignmentPerson.Models.Data;
using MVCAssignmentPerson.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.Service
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepo _languageRepo;

        public LanguageService(ILanguageRepo languageRepo)
        {
            _languageRepo = languageRepo;
        }


        public Language Add(CreateLanguage CreateLanguage)
        {
            Language language = new Language() { Name = CreateLanguage.Name };

           return _languageRepo.Create(language);
        }

        public List<Language> All()
        {
            return _languageRepo.Read();
        }
        public Language FindbyId(int id)
        {
            return _languageRepo.Read(id);
        }

        public Language Edit(int id, CreateLanguage language)
        {
            throw new NotImplementedException();
        }


        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
