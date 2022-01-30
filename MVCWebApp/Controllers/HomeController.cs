﻿using Microsoft.AspNetCore.Mvc;
using MVCWebApp.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProjectRepository _projectRepository;

        public HomeController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public IActionResult Index()
        {
            //Clean cookie
            //if (Request.Cookies["first_request"] != null)
            //{
            //    Response.Cookies.Delete("first_request");
            //}
            if (!HttpContext.Request.Cookies.ContainsKey("first_request"))
            {
                HttpContext.Response.Cookies.Append("first_request", DateTime.Now.ToString());
                HttpContext.Response.Cookies.Append("timesVisited", "1");
                ViewBag.Message = ("Welcome, new visitor!");

            }
            else
            {
                DateTime firstRequest = DateTime.Parse(HttpContext.Request.Cookies["first_request"]);
                int timesVisited = int.Parse((HttpContext.Request.Cookies["timesVisited"]));
                timesVisited++;
                HttpContext.Response.Cookies.Append("timesVisited", timesVisited.ToString());
                ViewBag.Message = ("Welcome back, user! You first visited us on: " + firstRequest.ToString() +
                                    " Amount of visits: " + timesVisited);
            }

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View(_projectRepository.GetAllProjects);
        }
    }
}
