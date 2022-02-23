using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models.Person.ViewModels
{
    public class CombinedPersonViewModel
    {
        public IEnumerable<Person> PersonList { get; set; }

        public CreatePersonViewModel CreateViewModel { get; set; }

        public string SearchTerm { get; set; }

        public SearchPersonViewModel SearchOptions { get; set; }

        public SortOptionsViewModel SortOptions { get; set; }
    }
}
