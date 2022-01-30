using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models.Home
{
    class MockProjectRepository : IProjectRepository
    {
        public IEnumerable<Project> GetAllProjects =>
            new List<Project>
            {
                new Project {Title = "Calculator", Description = "A simple console calculator", ImageFilepath = "/Content/Projects/calculator.png", Link = "https://github.com/mattiasgu87/Calculator", Categories = "C#"},
                new Project {Title = "Calculator V2", Description = "Updated calculator with more functionality and included XUnit testing", ImageFilepath = "/Content/Projects/calculatorV2Small.png", Link = "https://github.com/mattiasgu87/Calculator2.0", Categories = "C#"},
                new Project {Title = "Hangman", Description = "Hangman console game", ImageFilepath = "/Content/Projects/hangman.png", Link = "https://github.com/mattiasgu87/Hangman", Categories = "C#"},
                new Project {Title = "Front End Funtamentals assignment", Description = "A simple html/css webpage", ImageFilepath = "/Content/Projects/frontendSmall.png", Link = "https://github.com/mattiasgu87/Front-End-Fundamentals-Assignment", Categories = "Html/CSS"},
                new Project {Title = "Sokoban", Description = "A simple Sokoban clone with 3 stages", ImageFilepath = "/Content/Projects/sokoban.png", Link = "https://github.com/mattiasgu87/Sokoban", Categories = "Html/Javascript/CSS"}
            };
    }
}
