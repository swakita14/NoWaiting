using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NowaiterApi.Models
{
    public class Status
    {

        public int StatusId { get; set; }

        public int DriveThru { get; set; }

        public int InStore { get; set; }

        public int RestaurantId { get; set; }

    }
}
