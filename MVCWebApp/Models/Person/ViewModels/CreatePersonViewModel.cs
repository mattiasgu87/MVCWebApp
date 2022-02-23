using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models.Person.ViewModels
{
    public class CreatePersonViewModel
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]

        public string Name { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 1)]

        public string City { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 8)]
        public string PhoneNumber { get; set; }

        public CreatePersonViewModel() {}

        public CreatePersonViewModel(string name, string city, string pNumber)
        {
            Name = name;
            City = city;
            PhoneNumber = pNumber;
        }
    }
}
