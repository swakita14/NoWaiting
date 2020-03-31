using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NowaiterApi.Models
{
    public class Location
    {

        public int LocationId { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int RestaurantID { get; set; }

    }

}
