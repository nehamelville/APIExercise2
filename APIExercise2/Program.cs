using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace APIExercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            { 
                var client = new HttpClient();
                Console.Write("Enter the API key:");
                var apiKey = Console.ReadLine();
                Console.Write("Enter the city name:");
                var cityName = Console.ReadLine();
                var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&units=imperial&appid={apiKey}";
                var response = client.GetStringAsync(weatherURL).Result;
                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine(formattedResponse);
                Console.Write("Do you like to choose a different country?");
                var answer = Console.ReadLine();
                if(answer.ToLower()=="no")
                {
                    break;
                }
            }
        }
    }
}
