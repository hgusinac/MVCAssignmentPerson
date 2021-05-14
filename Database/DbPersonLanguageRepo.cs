using MVCAssignmentPerson.Models.Data;
using MVCAssignmentPerson.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Database
{
    public class DbPersonLanguageRepo : IPersonLanguageRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public DbPersonLanguageRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public PersonLanguage Create(PersonLanguage personLanguage)
        {
            _peopleDbContext.Add(personLanguage);

            if (_peopleDbContext.SaveChanges() > 0)
            {
                return personLanguage;
            }
            return null;
        }

       

        public List<PersonLanguage> Read()
        {
          return  _peopleDbContext.PersonLanguages.ToList();
        }

        public PersonLanguage Read(int personId, int langId)
        {
            return _peopleDbContext.PersonLanguages.SingleOrDefault(pl => pl.PersonId == personId && pl.LanguageId == langId);
        }

        public List<PersonLanguage> Read(int id)
        {
            return _peopleDbContext.PersonLanguages.Where(pl => pl.PersonId == id).ToList(); 
        }
        public bool Delete(int personId, int langId)
        {
            PersonLanguage pl = Read(personId, langId);
            if (pl == null)
            {
                return false;
            }
                _peopleDbContext.Remove(pl);
            int result = _peopleDbContext.SaveChanges();
            if(result == 0)
            {
                return false;

            }
            return true;
        }
    }
}
