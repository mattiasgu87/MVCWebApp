using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Controllers
{
    public class GuessingGameController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            #region resetcookie
            //CookieOptions cookieOption = new CookieOptions();
            //cookieOption.Expires = DateTime.Now.AddMinutes(1);

            //HttpContext.Response.Cookies.Append("highscore", "ss", cookieOption);
            #endregion

            Random rnd = new Random();
            if (HttpContext.Session.GetInt32("GuessingNumber") == null)
            {
                HttpContext.Session.SetInt32("GuessingNumber", rnd.Next(101));
                HttpContext.Session.SetInt32("NumberOfGuesses", 0);               
            }
            string sessionIDtext = HttpContext.Session.Id.ToString();
            ViewBag.Message = "Hidden number has been set! Guess a number 1-100!";
            return View();
        }

        [HttpPost]
        public IActionResult Index(int hiNumber)
        {
            if (hiNumber != 0)
            {
                HttpContext.Session.SetInt32("NumberOfGuesses", (int)HttpContext.Session.GetInt32("NumberOfGuesses") + 1);

                ViewBag.Message = "Amount of guesses made: " + HttpContext.Session.GetInt32("NumberOfGuesses") +
                                    "<br />You guessed: " + hiNumber;

                //temp highscore-> following cookie will only be set on response so use this for the viewbag or cookie will be null
                int temporaryHigscore = -1;

                if(hiNumber == (int)HttpContext.Session.GetInt32("GuessingNumber"))
                {             
                    #region cookie
                    if (!HttpContext.Request.Cookies.ContainsKey("highscore"))
                    {
                        CookieOptions cookieOption = new CookieOptions();
                        cookieOption.Expires = DateTime.Now.AddDays(1);

                        HttpContext.Response.Cookies.Append("highscore", HttpContext.Session.GetInt32("NumberOfGuesses").ToString(), cookieOption);
                        temporaryHigscore = (int)HttpContext.Session.GetInt32("NumberOfGuesses");
                    }
                    else
                    {
                        int _highscore;
                        int _getCurrentScore = (int)HttpContext.Session.GetInt32("NumberOfGuesses");
                        int.TryParse(HttpContext.Request.Cookies["highscore"], out _highscore);
                        if (_getCurrentScore < _highscore)
                        {
                            temporaryHigscore = _getCurrentScore;
                            CookieOptions cookieOption = new CookieOptions();
                            cookieOption.Expires = DateTime.Now.AddDays(1);

                            HttpContext.Response.Cookies.Append("highscore", HttpContext.Session.GetInt32("NumberOfGuesses").ToString(), cookieOption);
                        }
                        else
                            temporaryHigscore = _highscore; // fixa snyggare-> tänkt fel sätt bara på ett ställe istf 3
                    }
                    #endregion

                    Random rnd = new Random();
                    HttpContext.Session.SetInt32("GuessingNumber", rnd.Next(101));
                    HttpContext.Session.SetInt32("NumberOfGuesses", 0);
                    ViewBag.Message = ViewBag.Message + (" <br /> Your guess was correct! New Hidden number has been set!" + 
                                                        "Current Highscore: " + temporaryHigscore);
                }
                else if(hiNumber < HttpContext.Session.GetInt32("GuessingNumber"))
                {
                    ViewBag.Message = ViewBag.Message + (" <br /> Hidden number is higher than your guess!");
                }
                else if (hiNumber > HttpContext.Session.GetInt32("GuessingNumber"))
                {
                    ViewBag.Message = ViewBag.Message + (" <br /> Hidden number is lower than your guess!");
                }
            }
            else
                ViewBag.Message = "You can't guess numbers smaller than 1! guess again!";

            return View();
        }
    }
}
