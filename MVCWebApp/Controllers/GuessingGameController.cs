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
            Random rnd = new Random();
            if (HttpContext.Session.GetInt32("GuessingNumber") == null)
            {
                HttpContext.Session.SetInt32("GuessingNumber", rnd.Next(101));
                HttpContext.Session.SetInt32("NumberOfGuesses", 0);               
            }

            ViewBag.Message = "Hidden number has been set! Guess a number 1-100!";

            ////check if highscore cookie exists
            if (!HttpContext.Request.Cookies.ContainsKey("highscore"))
            {
                //default highscore = 1000000
                SetHighscoreCookie(1000000);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Index(int hiNumber)
        {
            if (hiNumber > 0)
            {
                int _highscoreTest;
                bool wonGame;
                bool newHighScore;

                //get amount of guesses and update session value
                int tries = (int)HttpContext.Session.GetInt32("NumberOfGuesses") + 1;
                HttpContext.Session.SetInt32("NumberOfGuesses", tries);

                int.TryParse(HttpContext.Request.Cookies["highscore"], out _highscoreTest);

                ViewBag.Message = Models.GuessingGame.GuessingGame.Guess((int)HttpContext.Session.GetInt32("GuessingNumber"),
                    hiNumber, tries, _highscoreTest, out wonGame, out newHighScore); 

                if(wonGame)
                {
                    if(newHighScore)
                    {
                        SetHighscoreCookie(tries);
                    }

                    Random rnd = new Random();
                    HttpContext.Session.SetInt32("GuessingNumber", rnd.Next(101));
                    HttpContext.Session.SetInt32("NumberOfGuesses", 0);
                }
            }
            else
                ViewBag.Message = "You can't guess numbers smaller than 1! guess again!";

            return View();
        }

        /// <summary>
        /// Method for easy reset of highscore cookie
        /// </summary>
        private void ResetHighscoreCookie()
        {          
            CookieOptions cookieOptionReset = new CookieOptions();
            cookieOptionReset.Expires = DateTime.Now.AddDays(-1);

            //default highscore = 1000000
            HttpContext.Response.Cookies.Append("highscore", "1000000", cookieOptionReset);
        }

        private void SetHighscoreCookie(int highscore)
        {
            CookieOptions cookieOption = new CookieOptions();
            cookieOption.Expires = DateTime.Now.AddDays(1);

            HttpContext.Response.Cookies.Append("highscore", highscore.ToString(), cookieOption);
        }
    }   
}
