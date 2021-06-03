using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCAssignmentPerson.Models.Data;
using MVCAssignmentPerson.Models.Service;
using MVCAssignmentPerson.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace MVCAssignmentPerson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ApiPolicy")]
    public class ApiController : ControllerBase
    {
        private readonly IPeopleService _peopleService;
        private readonly ILanguageService _languageService;
        private readonly IPersonLanguageService _personLanguageService;
        private readonly ICityService _cityService;

        public ApiController(IPeopleService peopleService, ILanguageService languageService, IPersonLanguageService personLanguageService, ICityService cityService)
        {
            _peopleService = peopleService;
            _languageService = languageService;
            _personLanguageService = personLanguageService;
            _cityService = cityService;
        }



        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return Ok(_peopleService.AllPerson());
        }

        [HttpGet("{id}")]
        public Person Get(int id)
        {
            Person person = _peopleService.FindbyId(id);


            foreach (var pl in person.PersonLanguages) // stoppar från att gå tillbaka och loopa person. 
            {
                pl.Person = null;
                pl.Language.PersonLanguages = null;
            }

            
            if (person.InCityId != null )
            {
                person.InCity = _cityService.FindbyId((int)person.InCityId);
                person.InCity.PersonsInCity = null;

                if(person.InCity.Country != null)
                {
                    person.InCity.Country.CityInCountry = null;
                }
            }

            


            return person;

        }

        [HttpPost]
        public int Post([FromBody] CreatePersonViewModel newPerson)
        {
            if (!ModelState.IsValid)
            {
                return Response.StatusCode = 400;
            }

            Person person = _peopleService.Add(newPerson);
            if (person == null)
            {
                return Response.StatusCode = 500;
            }

            return Response.StatusCode = 201;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Person person = _peopleService.FindbyId(id);
            if (person == null)
            {
                Response.StatusCode = 404;
            }
            else if (!_peopleService.Remove(id))
            {

                Response.StatusCode = 500;
            }
            else
            {

                Response.StatusCode = 200;
            }



        }

    }
}
