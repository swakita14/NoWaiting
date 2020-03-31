using System;
using System.Collections.Generic;
using System.Text;
using GooglePlaces.Lib.Interface;
using RestSharp;

namespace GooglePlaces.Lib.Services
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

    }
}
