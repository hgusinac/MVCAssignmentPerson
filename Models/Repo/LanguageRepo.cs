using MVCAssignmentPerson.Database;
using MVCAssignmentPerson.Models.Data;
using MVCAssignmentPerson.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.Repo
{
    public class LanguageRepo : ILanguageRepo
    {
        private readonly PeopleDbContext _peopleDbContext;

        public LanguageRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public Language Create(Language language)
        {
            _peopleDbContext.Add(language);
            if(_peopleDbContext.SaveChanges() > 0)
            {
                return language;
            }
            return null;
        }

       

        public List<Language> Read()
        {
           return _peopleDbContext.Languages.ToList();
        }

        public Language Read(int id)
        {
            return _peopleDbContext.Languages.SingleOrDefault(language=> language.Id == id);
        }

        public Language Update(Language language)
        {
            Language originalLanguage = Read(language.Id);
            if(originalLanguage == null)
            {
                return null;
            }
            _peopleDbContext.Update(language);

            if (_peopleDbContext.SaveChanges() > 0)
            {
                return language;
            }
            return null;
        }
        public bool Delete(int id)
        {
            Language language = Read(id);

            if (language == null)
            {
                return false;
            }


            _peopleDbContext.Languages.Remove(language);

            if (_peopleDbContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
