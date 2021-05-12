using MVCAssignmentPerson.Database;
using MVCAssignmentPerson.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.Repo
{
    public class PersonLanguageRepo : IPersonLanguageRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public PersonLanguageRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public PersonLanguage Create(PersonLanguage personLanguage)
        {
            _peopleDbContext.PersonLanguages.Add(personLanguage);

            if (_peopleDbContext.SaveChanges() > 0)
            {
                return personLanguage;
            }
            return null;
        }

        

        public PersonLanguage Read(int personId, int langId)
        {
            return _peopleDbContext.PersonLanguages.SingleOrDefault(pl => pl.PersonId == personId && pl.LanguageId == langId);
        }

        public List<PersonLanguage> Read()
        {
            return _peopleDbContext.PersonLanguages.ToList();
        }
        public bool Delete(int personId, int langId)
        {
            PersonLanguage personLanguage = Read(personId, langId);

            if (personLanguage == null)
            {
                return false;
            }


            _peopleDbContext.PersonLanguages.Remove(personLanguage);

            if (_peopleDbContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
