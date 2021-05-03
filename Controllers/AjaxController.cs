using Microsoft.AspNetCore.Mvc;
using MVCAssignmentPerson.Models.Data;
using MVCAssignmentPerson.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Controllers
{
    public class AjaxController : Controller
    {
        readonly IPeopleService _peopleService = new PeopleService();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            return PartialView("_AjaxPeopleListPartialView", _peopleService.All().PeopleList);
        }

        [HttpPost]
        public IActionResult PartialDetails(int id)
        {
            Person person = _peopleService.FindbyId(id);
            if (person == null)
            {
                return NotFound();
            }
            return PartialView("_AjaxPeopleDetails", person);
        }

        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Person person = _peopleService.FindbyId(id);

            if (person == null)
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
