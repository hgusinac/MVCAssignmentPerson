using MVCAssignmentPerson.Models.Data;
using MVCAssignmentPerson.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.Service
{
    public class PersonLanguageService : IPersonLanguageService
    {
        private readonly IPersonLanguageRepo _personLanguageRepo;

        public PersonLanguageService( IPersonLanguageRepo personLanguageRepo)
        {
            _personLanguageRepo = personLanguageRepo;
        }
        public PersonLanguage Add(PersonLanguage personLanguage)
        {
            return _personLanguageRepo.Create(personLanguage);
        }

        public PersonLanguage Add(int personId, int langId)
        {
            PersonLanguage pl = new PersonLanguage();
            pl.LanguageId = langId;
            pl.PersonId = personId;

            return Add(pl);
        }

        public List<PersonLanguage> All()
        {
            return _personLanguageRepo.Read();
        }

        

        public PersonLanguage FindbyId(int id, int personLanguageId)
        {
            return _personLanguageRepo.Read(id, personLanguageId);
        }

        public List<PersonLanguage> FindbyId(int id)
        {
            return _personLanguageRepo.Read(id);
        }
        public bool Delete(int personId, int langId)
        {
            return _personLanguageRepo.Delete(personId, langId);
        }
    }
}
