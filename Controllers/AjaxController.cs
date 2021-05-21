using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCAssignmentPerson.Models.Data;
using MVCAssignmentPerson.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Controllers
{
    [Authorize]
    public class AjaxController : Controller
    {
        IPeopleService _peopleService;
        public AjaxController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }
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
