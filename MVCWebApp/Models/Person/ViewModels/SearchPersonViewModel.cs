using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models.Person.ViewModels
{
    public class SearchPersonViewModel
    {
        public string SearchTerm { get; set; }
        public bool CaseSensitive { get; set; }
    }
}
