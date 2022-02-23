using MVCWebApp.Models.Person.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models.Person
{
    public class MockPersonRepository : IPersonRepository
    {
        private static int idCounter = 0;
        private static List<Person> PersonList = new List<Person>();

        public MockPersonRepository()
        {
            Person p1 = new Person { Name = "John Doe", City = "New York", PhoneNumber = "324432234", ID = GetNewID() };
            Person p2 = new Person { Name = "Jane Doe", City = "Las Vegas", PhoneNumber = "3453455433", ID= GetNewID()
    };

            PersonList.Add(p1);
            PersonList.Add(p2);
        }

        public List<Person> GetAllPersons()
        {
            return PersonList;
        }

        public List<Person> Search(string searchTerm, bool caseSensitive)
        {
            List<Person> searchList = new List<Person>();

            if (searchTerm != null)
            {
                foreach (Person item in PersonList)
                {
                    if(caseSensitive)
                    {
                        if (item.Name.Contains(searchTerm) || item.City.Contains(searchTerm))
                        {
                            searchList.Add(item);
                        }
                    }
                    else
                    {
                        if (item.Name.Contains(searchTerm.ToLowerInvariant()) || item.City.Contains(searchTerm.ToLowerInvariant()))
                        {
                            searchList.Add(item);
                        }
                    }
                    
                }
            }
            return searchList;
        }

        public List<Person> Sort(SortOptionsViewModel sortOptions, string sortType)
        {
            //default by ID
            List<Person> sortedList = PersonList.OrderBy(p => p.ID).ToList();

            if (sortType == "city")
            {
                sortedList = PersonList.OrderBy(p => p.City).ToList();              
            }
            else if(sortType == "name")
            {
                sortedList = PersonList.OrderBy(p => p.Name).ToList();
            }

            if (sortOptions.ReverseAplhabeticalOrder == true)
            {
                sortedList.Reverse();
            }

            return sortedList;
        }

        public Person Add(CreatePersonViewModel createPersonViewModel)
        {
            Person person = new Person();
            person.Name = createPersonViewModel.Name;
            person.City = createPersonViewModel.City;
            person.PhoneNumber = createPersonViewModel.PhoneNumber;
            person.ID = GetNewID();

            PersonList.Add(person);

            return person;
        }

        public bool Delete(int id)
        {
            if (id > 0)
            {
                Person personToRemove = null;

                foreach (Person item in PersonList)
                {
                    if (item.ID == id)
                    {
                        personToRemove = item;
                    }
                }

                if (personToRemove != null)
                {
                    PersonList.Remove(personToRemove);
                    return true;
                }
            }

            return false;
        }

        private int GetNewID()
        {
            idCounter++;
            return idCounter;
        }
    }
}