using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using NowaiterApi.Interfaces.Service;
using RestSharp;
using NowaiterApi.Models.GooglePlaces;
using NowaiterApi.Models.GooglePlaces.QuickType;
using Location = NowaiterApi.Models.GooglePlaces.Location;

namespace NowaiterApi.Client
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
         * 
         */
        public List<string> GetPlacesList()
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
            List<PlacesResponse> places = new List<PlacesResponse>();

            // Looping through the city and adding the places api result 
            foreach (var city in cities)
            {
                places.Add(GetPlacesResult("restaurant", city, "1000"));
            }

            // Initialize result list 
            List<string> placesIdList = new List<string>();

            // Foreach api response
            foreach (var place in places)
            {
                // Return only the results of the api response 
                foreach (var results in place.Results)
                {
                    // Add each result to result list 
                    placesIdList.Add(results.PlaceId);
                }
            }

            // Return the list of places from response 
            return placesIdList;
        }

        /**
         * This method will call the Google Places API and grab the response and return result
         * <param name="type">look up the status</param>
         * <param name="location">add geo-coordinates to the request</param>
         */
        public PlacesResponse GetPlacesResult(string type, Location location, string radius)
        {
            // Initializing Request and adding API Key to it
            RestRequest request = new RestRequest("nearbysearch/json?", Method.GET);
            request.AddQueryParameter("key", _apiKey);

            // Adding parameters to look for places with near addresses
            request.AddQueryParameter("type", type);
            request.AddQueryParameter("location", $"{location.Lat},{location.Lng}");
            request.AddQueryParameter("radius", radius);

            // Get response with request
            IRestResponse response = _client.Execute(request);

            // Convert result into model and return response
            PlacesResponse apiResult = JsonConvert.DeserializeObject<PlacesResponse>(response.Content);

            // Return Result 
            return apiResult;
        }

        /**
         * This method takes in the places_id from the google api and searches details 
         */
        public DetailResult GetDetailResult(string placeId)
        {
            // Initializing Request and adding API Key to it
            RestRequest request = new RestRequest("details/json?", Method.GET);
            request.AddQueryParameter("key", _apiKey);

            // Adding parameters to look for places with near addresses
            request.AddQueryParameter("place_id", placeId);

            // Get response with request
            IRestResponse response = _client.Execute(request);

            // Convert result into model and return response
            DetailSearch apiResult = JsonConvert.DeserializeObject<DetailSearch>(response.Content);

            // Return Result 
            return apiResult.Result;
        }

    }
}
