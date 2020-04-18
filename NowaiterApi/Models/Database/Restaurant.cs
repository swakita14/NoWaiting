using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NowaiterApi.Models.GooglePlaces;

namespace NowaiterApi.Models
{
    public class Restaurant
    {

        public int RestaurantId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public DateTime? DateUpdated { get; set; }

        public string GooglePlaceId { get; set; }

    }

}
