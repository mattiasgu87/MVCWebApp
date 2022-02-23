using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models.Person
{
    public class Person
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }

        public int ID { get; set; }

        public Person() { ID = 0; }
    }
}
