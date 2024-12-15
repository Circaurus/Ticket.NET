using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TicketNET.Models;
using System.Collections.Generic;
using System.Net;

namespace TicketNET
{
    public class TMClient
    {
        private const string Endpoint = "https://app.ticketmaster.com/discovery/v2/";
        private const string eventRoute = "events.json?";
        private const string classificationName = "classificationName=music&";

        public string Country {  get; private set; }

        public TMClient(string country)
        {
            Country = country;
        }


        public async Task<Events> GetEventsAsync(string apiKey)
        {
            var result = await GetEventRequestAsync<Events>(classificationName, apiKey);

            return result;
        }



        private async Task<T> GetEventRequestAsync<T>(string request, string apiKey)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Endpoint);

                    var result = await client.GetAsync(eventRoute + request + apiKey);
                    var contents = await result.Content.ReadAsStringAsync();
                    var modelObject = JsonConvert.DeserializeObject<T>(contents);

                    return modelObject;
                }
            }
            catch (Exception ex) 
            {
                return default(T);
            }
        }


    }
}
