using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models.GuessingGame
{
    public class GuessingGame
    {
        public static string Guess(int secretNumber, int guess, int tries, int highScore, out bool wonGame, out bool newHighScore)
        {
            string message = string.Empty;
            wonGame = false;
            newHighScore = false;
            int tempHighScore = highScore;

            message = "Amount of guesses made: " + tries + "<br />You guessed: " + guess;

            if (guess == secretNumber)
            {
                wonGame = true;

                if (tries < highScore)
                {
                    newHighScore = true;
                    tempHighScore = tries;
                }

                message += (" <br /> Your guess was correct! New Hidden number has been set!" +
                                                        "Current Highscore: " + tempHighScore);             
            }
            else if(guess < secretNumber)
            {
                message += " <br /> Hidden number is higher than your guess!";
            }
            else if(guess > secretNumber)
            {
                message += " <br /> Hidden number is lower than your guess!";
            }

            return message;
        }
    }
}