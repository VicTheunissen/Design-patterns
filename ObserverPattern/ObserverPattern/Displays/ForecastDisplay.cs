using ObserverPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Displays
{
    internal class ForecastDisplay : Observer, DisplayElement
    {
        private float temperature;
        private float humidity;
        private Subject weatherData;
        public ForecastDisplay(Subject weatherData)
        {
            // Set the field and register itself with the weatherdata subject
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }
        public void Update(float temp, float humidity, float pressure)
        {
            // Set the correct fields with the relevant parameters
            this.temperature = temp;
            this.humidity = humidity;
            Display();
        }

        public void Display()
        {
            // Print a forecast message based on the current temperature and humidity
            string forecast;

            if (temperature >= 25 && humidity < 60)
            {
                forecast = "Mooi weer komt er aan!";
            }
            else if (humidity >= 80)
            {
                forecast = "Trek je paraplu's uit de kast, regen op komst!";
            }
            else if (temperature < 15)
            {
                forecast = "Het wordt kouder, trek een jas aan!";
            }
            else
            {
                forecast = "Wisselvallig weer, houd rekening met verandering.";
            }

            Console.WriteLine($"Voorspelling: {forecast}");
        }
    }
}
