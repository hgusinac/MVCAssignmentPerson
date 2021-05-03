using Microsoft.AspNetCore.Mvc;
using MVCAssignmentPerson.Models.Data;
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
        readonly IPeopleService _peopleService = new PeopleService();


        [HttpGet]
        public IActionResult Index()
        {
            return View(_peopleService.All());
        }

        [HttpPost]
        public IActionResult Index(PeopleViewModel searchViewModel)
        {
            PeopleViewModel filteredModel = _peopleService.FindBy(searchViewModel);
            searchViewModel.PeopleList = filteredModel.PeopleList;

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
        public IActionResult Edit(int id)
        {
            Person person = _peopleService.FindbyId(id);

            if (person == null)
            {
                return RedirectToAction(nameof(Index));
            }

            EditPerson editPerson = new EditPerson(id, person);


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
