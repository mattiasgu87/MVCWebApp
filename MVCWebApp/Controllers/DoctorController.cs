using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CheckFever(string temperature, /*float temperature,*/ string radioData)
        {
            //string instead of float beacuse of weird bug-> 10,1 as float returned 101 previously
            if (float.TryParse(temperature, out float temperatureFloat))
            {
                ViewBag.Message = Models.Doctor.FeverCheckModel.CheckForFever(temperatureFloat);
            }
            else
            {
                ViewBag.Message = "Please enter a valid temperature! (format example: 37,7)";
            }
            return View("index");
        }

        [HttpPost]
        public ActionResult Index(Models.Doctor.TemperatureModel temp, string tempType)
        {
            temp.Type = tempType;
            if (temp.Temperature != null)
            {
                ViewBag.Message = Models.Doctor.FeverCheckModel.CheckForFever(temp);               
            }
            else
            {
                //assignment specified no response, keep/remove?
                //ViewBag.Message = "Please enter a valid temperature! (format example: 37,7)";
            }

            ViewBag.ISChecked = tempType;

            return View();
        }
    }
}
