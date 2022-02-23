using Microsoft.AspNetCore.Mvc;
using MVCWebApp.Models.Person;
using MVCWebApp.Models.Person.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public IActionResult Index()
        {
            CombinedPersonViewModel model = new CombinedPersonViewModel();
            model.PersonList = _personRepository.GetAllPersons();

            return View(model);
        }
        //[HttpGet]
        //public IActionResult Index(List<Person> list)
        //{
        //    CombinedPersonViewModel model = new CombinedPersonViewModel();
        //    model.PersonList = list;

        //    return View(model);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CreatePersonViewModel CreateViewModel) // change to only create later
        {
            _personRepository.Add(CreateViewModel);

            CombinedPersonViewModel model = new CombinedPersonViewModel();
            model.PersonList = _personRepository.GetAllPersons();

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _personRepository.Delete(id);

            CombinedPersonViewModel model = new CombinedPersonViewModel();
            model.PersonList = _personRepository.GetAllPersons();

            return View(nameof(Index), model);
        }

        [HttpPost]
        public IActionResult Search(SearchPersonViewModel searchOptions)
        {

            CombinedPersonViewModel model = new CombinedPersonViewModel();
            model.PersonList = _personRepository.Search(searchOptions.SearchTerm, searchOptions.CaseSensitive);          

            return View(nameof(Index), model);
        }

        [HttpPost]
        public IActionResult SortByCity(SortOptionsViewModel sortOptions)
        {
            CombinedPersonViewModel model = new CombinedPersonViewModel();

            model.PersonList = _personRepository.Sort(sortOptions, "city");

            return View(nameof(Index), model);
        }

        [HttpPost]
        public IActionResult SortByName(SortOptionsViewModel sortOptions)
        {
            CombinedPersonViewModel model = new CombinedPersonViewModel();

            model.PersonList = model.PersonList = _personRepository.Sort(sortOptions, "name");

            return View(nameof(Index), model);
        }
    }
}
