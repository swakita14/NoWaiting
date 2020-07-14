using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NowaiterApi.Models
{
    public class Location
    {

        public int LocationId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int RestaurantId { get; set; }

    }

}
