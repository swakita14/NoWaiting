using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using NowaiterApi.Interfaces.Service;
using RestSharp;
using NowaiterApi.Models.GooglePlaces;

namespace NowaiterApi.Services
{
    public class PlacesClient : IPlacesClient
    {
        private static IRestClient _client;
        private readonly string _apiKey;

        public PlacesClient(IRestClient client, string apiKey)
        {
            _client = client;
            _apiKey = apiKey;
        }

        /**
         * This method utilizes the GetPlace method and retrieves a list of places with different addresses/locations
         * Source Code Model: RecNexus by Shayna
         */
        public List<PlacesResult> GetPlacesList()
        {
            // Initializing cities with their geolocation 
            List<Location> cities = new List<Location>
            {
                // Monmouth 
                new Location { Lat = 44.9429, Lng = -123.0351 },

                // Independence
                new Location { Lat = 44.8512, Lng = -123.1868 }
            };

            // Initialize list to store places 
            List<PlacesResult> places = new List<PlacesResult>();

            // Looping through the city and adding the places api result 
            foreach (var city in cities)
            {
                PlacesResult restaurants = GetPlacesResult("restaurant", city);
            }

            // Return the list of places from response 
            return places;
        }

        /**
         * This method will call the Google Places API and grab the response and return result
         * Source Code Model: RecNexus by Shayna
         * <param name="type">look up the status</param>
         * <param name="location">add geo-coordinates to the request</param>
         */
        public PlacesResult GetPlacesResult(string type, Location location)
        {
            // Initializing Request and adding API Key to it
            RestRequest request = new RestRequest("nearbysearch/json?", Method.GET);
            request.AddQueryParameter("key", _apiKey);

            // Adding parameters to look for places with near addresses
            request.AddQueryParameter("type", type);
            request.AddQueryParameter("location", $"{location.Lat} , {location.Lng}");

            // Get response with request
            IRestResponse response = _client.Execute(request);

            // Convert result into model and return response
            PlacesResult apiResult = JsonConvert.DeserializeObject<PlacesResult>(response.Content);

            // Return Result 
            return apiResult;


        }
    }
}
