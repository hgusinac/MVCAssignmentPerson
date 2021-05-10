using Microsoft.AspNetCore.Mvc;
using MVCAssignmentPerson.Models.Service;
using MVCAssignmentPerson.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            CreateCountry createCountry = new CreateCountry();
            return View(createCountry);
        }
        public IActionResult Create(CreateCountry createCountry)
        {
            if (ModelState.IsValid)
            {
                _countryService.Add(createCountry);
                return RedirectToAction(nameof(Index));
            }
            return View(createCountry);
        }
    }
}
