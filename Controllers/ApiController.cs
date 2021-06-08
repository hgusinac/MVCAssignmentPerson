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
        private readonly ICountryService _countryService;

        public ApiController(IPeopleService peopleService, ILanguageService languageService, IPersonLanguageService personLanguageService,
            ICityService cityService, ICountryService countryService)
        {
            _peopleService = peopleService;
            _languageService = languageService;
            _personLanguageService = personLanguageService;
            _cityService = cityService;
            _countryService = countryService;
        }



        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {
            return Ok(_peopleService.AllPerson());
        }

        [HttpGet("/api/Cities")]
        public ActionResult<City> GetCities()
        {
            List<City> city = _cityService.All();
            foreach(var item in city)
            {
                item.Country = null;
                item.PersonsInCity = null;

            }
            return Ok(city);
        }

        [HttpGet("/api/Countries")]
        public ActionResult <Country> GetCountries()
        {
            List<Country> country = _countryService.All();
            foreach (var item in country)
            {
                item.CityInCountry = null;
            }
            return Ok(country);
        }

        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            Person person = _peopleService.FindbyId(id);

            if (person == null)
            {
                return BadRequest();
            }

            foreach (var pl in person.PersonLanguages) // stoppar från att gå tillbaka och loopa person. 
            {
                pl.Person = null;
                pl.Language.PersonLanguages = null;
            }


            if (person.InCityId != null)
            {
                person.InCity = _cityService.FindbyId((int)person.InCityId);
                person.InCity.PersonsInCity = null;

                if (person.InCity.Country != null)
                {
                    person.InCity.Country.CityInCountry = null;
                }
            }




            return person;

        }

        [HttpPost]
        public ActionResult<Person> Post([FromBody] CreatePersonViewModel newPerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(newPerson);
            }

            Person person = _peopleService.Add(newPerson);
            if (person == null)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Created("", person);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (_peopleService.Remove(id))
            {
                Response.StatusCode = 200;
            }
            else
            {
                Response.StatusCode = 400;
            }



        }
        

    }
}
