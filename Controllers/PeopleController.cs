using Microsoft.AspNetCore.Mvc;
using MVCAssignmentPerson.Models.Data;
using MVCAssignmentPerson.Models.Repo;
using MVCAssignmentPerson.Models.Service;
using MVCAssignmentPerson.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Controllers
{
    public class PeopleController : Controller
    {
        IPeopleService _peopleService;
        
        private readonly ILanguageService _languageService;
        private readonly IPersonLanguageService _personLanguageService;
        private readonly ICityService _cityService;


        public PeopleController(IPeopleService peopleService, ILanguageService languageService,IPersonLanguageService personLanguageService,ICityService cityService)//Constructor injection 
        {
            _peopleService = peopleService;
            _languageService = languageService;
            _personLanguageService = personLanguageService;
            _cityService = cityService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View(_peopleService.All());
        }
        



        [HttpPost]
        public IActionResult Index(PeopleViewModel searchViewModel)
        {
             _peopleService.FindBy(searchViewModel);

            ModelState.Clear();
            return View(searchViewModel);

        }
       

        [HttpPost]
        public IActionResult Create(PeopleViewModel createPerson)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(createPerson.CreatePersonViewModel);

            }
            createPerson = _peopleService.All();
            return View("Index", createPerson);
        }
        [HttpGet]
        public IActionResult ManagePersonLanguages(int id)
        {
            Person person = _peopleService.FindbyId(id);

            if (person == null)
            {
                return RedirectToAction("Index");
            }


            PersonLanguagesViewModel vm = new PersonLanguagesViewModel();
            vm.Person = person;
            vm.Languages = _languageService.All();


            return View(vm);
        }
        [HttpGet]
        public IActionResult AddLanguageToPerson(int personId, int langId)
        {
            Person person = _peopleService.FindbyId(personId);

            if (person == null)
            {
                return RedirectToAction("Index");
            }


            PersonLanguage personLanguage = _personLanguageService.Add(// Ändra till Service
                new PersonLanguage() { PersonId = personId, LanguageId = langId });





            return RedirectToAction("ManagePersonLanguages", new { id = personId });

        }
        [HttpGet]
        public IActionResult RemoveLanguageToPerson(int personId, int langId)
        {
            Person person = _peopleService.FindbyId(personId);

            if (person == null)
            {
                return RedirectToAction("Index");
            }


          _personLanguageService.Delete(personId,langId );



            return RedirectToAction("ManagePersonLanguages", new { id = personId });

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Person person = _peopleService.FindbyId(id);

            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }

            EditPerson editPerson = new EditPerson(id, person);

            editPerson.Citylist = _cityService.All(); // Hela listan av Citys


            return View(editPerson);
        }
        [HttpPost]
        public IActionResult Edit(int id, CreatePersonViewModel createPerson)
        {
            Person person = _peopleService.FindbyId(id);
            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                _peopleService.Edit(id, createPerson);


                return RedirectToAction(nameof(Index));
            }
            EditPerson editPerson = new EditPerson(id, createPerson);
            editPerson.Citylist = _cityService.All();//

            return View(editPerson);

        }


        public IActionResult Delete(int id)
        {
            Person person = _peopleService.FindbyId(id);

            if(person == null)
            {
                return NotFound();
            }
            if (_peopleService.Remove(id))
            {
                return Ok("Person " + id);
            }
            return BadRequest();
        }





    }
}
