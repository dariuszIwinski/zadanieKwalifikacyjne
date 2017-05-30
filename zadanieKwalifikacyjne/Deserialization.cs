using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Data;

namespace zadanieKwalifikacyjne
{
    public static class Deserialization
    {
        public static Day ImportDeserializedDataFromAPI(string city, string date)
        {
            //wyswietlenie danych
            try
            {
                //pobranie danych
                string json = GetDataFromAPI(city, date);

                //częściowa deserializacja
                //stworzenie obiektu JSon
                JObject weatherSearch = JObject.Parse(json);
                //wsakazanie ścieżki do listy
                IList<JToken> results = weatherSearch["forecast"]["forecastday"].Children().ToList();

                //stworzenie obiektu z danymi z dnia
                Day daySearched = new Day();

                foreach (JToken result in results)
                {
                    //stworzenie obiektu JSon dla elementu listy
                    JObject weatherSearchDay = JObject.FromObject(result);
                    daySearched.maxtemp_c = Convert.ToDouble(weatherSearchDay["day"]["maxtemp_c"]);
                    daySearched.mintemp_c = Convert.ToDouble(weatherSearchDay["day"]["mintemp_c"]);
                    daySearched.avgtemp_c = Convert.ToDouble(weatherSearchDay["day"]["avgtemp_c"]);
                    daySearched.maxwind_mph = Convert.ToDouble(weatherSearchDay["day"]["maxwind_mph"]);
                    daySearched.avghumidity = Convert.ToDouble(weatherSearchDay["day"]["avghumidity"]);
                }

                return daySearched;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static string GetDataFromAPI(string city, string date)
        {
            //GET - hisorical
            try
            {
                var client = new RestClient("http://api.apixu.com/");
                var request = new RestRequest("v1/history.json?key=dceb7122a19f4f54a8011411172805&q=" + city + "&dt=" + date, Method.GET);
                var queryResult = client.Execute(request);
                string response = queryResult.Content;
                return response;
            }
            catch (Exception ex)
            {
                string response = ex.ToString();
                return response;
            }
        }



    }
}