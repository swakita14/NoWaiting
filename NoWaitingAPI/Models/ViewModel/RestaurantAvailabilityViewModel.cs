using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NowaiterApi.Models.ViewModel
{
    public class RestaurantAvailabilityViewModel
    {
        public int RestaurantId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address1 { get; set; }

        public int? DriveThru { get; set; }

        public int? InStore { get; set; }
    }
}
