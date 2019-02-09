using learnForms.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace learnForms.Services
{
    public class ApiServices
    {
        private static string domain = "https://cinemoapi20190207035839.azurewebsites.net";// "http://localhost:59304";
        private static string keyname = "apikey";// "qwer";
        private string nowPlaying = domain + "/api/nowplayingmovies";
        private string apiKey = "b580fee9-b15e-4a70-a855-f62e774264d4";// "77b562ba-e047-4b25-b6d9-b902e202cdcd ";// "d5ee54df-3497-4e53-8cc0-c4f9212b92e2";

        public async Task<List<NowPlayingMovies>> GetNowPlayingMovies()
        {
            List<NowPlayingMovies> nowPlayingMovies;
            try
            {
                var client = new HttpClient();
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, nowPlaying);
                requestMessage.Headers.Add(keyname, apiKey);
                var responseMessage = await client.SendAsync(requestMessage);
                var movieResponse = await responseMessage.Content.ReadAsStringAsync();
                nowPlayingMovies = Newtonsoft.Json.JsonConvert.DeserializeObject<List<NowPlayingMovies>>(movieResponse);
            }
            catch (Exception ex)
            {

                throw;
            }

            return nowPlayingMovies;
        }
        private string upcomingMovies = domain + "/api/upcomingmovies";
        public async Task<List<Upcoming>> GetUpComingMovies()
        {
            var client = new HttpClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, upcomingMovies);
            requestMessage.Headers.Add(keyname, apiKey);
            var responseMessage = await client.SendAsync(requestMessage);
            var movieResponse = await responseMessage.Content.ReadAsStringAsync();
            List<Upcoming> upcoming = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Upcoming>>(movieResponse);
            return upcoming;
        }
        private string orderTicket = domain + "/api/orders";
        public async Task<bool> Order(RequestObject bookTicket)
        {
            var httpClient = new HttpClient();
            var serializedObj = JsonConvert.SerializeObject(bookTicket);
            var content = new StringContent(serializedObj, Encoding.UTF8, "application/json");
            content.Headers.Add(keyname, apiKey);
            var response =   await httpClient.PostAsync(orderTicket, content);
            return response.IsSuccessStatusCode;
        }
    }
}
