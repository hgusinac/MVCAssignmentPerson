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
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        private readonly IPeopleRepo _peopleRepo;

        public CityController(ICityService cityService, ICountryService countryService, IPeopleRepo peopleRepo)
        {
            _cityService = cityService;
            _countryService = countryService;
           _peopleRepo = peopleRepo;
        }
        public IActionResult Index()
        {
            return View(_cityService.All());
        }
        public IActionResult Create()
        {
            CreateCity createCity = new CreateCity();
            createCity.CountryList = _countryService.All();
            return View(createCity);

        }
        [HttpPost]
        public IActionResult Create(CreateCity createCity)
        {
            if (ModelState.IsValid)
            {
                _cityService.Add(createCity);
                return RedirectToAction(nameof(Index));
            }
            return View(createCity);
        }
    }
}
