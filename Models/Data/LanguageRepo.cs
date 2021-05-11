using MVCAssignmentPerson.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Models.Data
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

            if(_peopleDbContext.SaveChanges() > 0)//int result 0 
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
            return _peopleDbContext.Languages.SingleOrDefault(language => language.Id == id);
        }

        public Language Update(Language language)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
