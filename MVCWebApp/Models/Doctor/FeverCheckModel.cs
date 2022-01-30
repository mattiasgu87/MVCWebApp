using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Models.Doctor
{
    public class FeverCheckModel
    {
        public static string CheckForFever(float temperature)
        {
            if (temperature >= 38.0)
                return "You have " + temperature + "°C which means you have a fever!";
            else if (0.0 <= temperature && temperature <= 35)
                return "You have " + temperature + "°C which means you have hypothermia!";
            else if (temperature < 0.0)
                return "You have " + temperature + "°C which means you are frozen!!!";
            else
                return "You have " + temperature + "°C which means you have normal temperature.";
        }

        public static string CheckforFeverFahrenheit(float temperature)
        {
            if (temperature >= 100.4)
                return "You have " + temperature + "°F which means you have a fever!";
            else if(32.0 <= temperature && temperature <= 95.0)
                return "You have " + temperature + "°F which means you have hypothermia!";
            else if (temperature < 32.0)
                return "You have " + temperature + "°F which means you are frozen!!!";
            else
                return "You have " + temperature + "°F which means you have normal temperature.";
        }

        public static string CheckForFever(TemperatureModel tempModel)
        {
            if (tempModel.Type == "Celsius")
            {
                //Obs testa för null!?!?!?!?!?!
                return CheckForFever((float)tempModel.Temperature);
            }
            else if (tempModel.Type == "Fahrenheit")
            {
                //Obs testa för null!?!?!?!?!?!
                return CheckforFeverFahrenheit((float)tempModel.Temperature);
            }
            else
                return "Please pick a temperature type! (unknow type)";
        }
    }
}
