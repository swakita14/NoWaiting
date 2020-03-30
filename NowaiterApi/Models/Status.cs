using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NowaiterApi.Models
{
    public class Status
    {

        public int StatusID { get; set; }

        public int? Drive_Thru { get; set; }

        public int? In_Store { get; set; }

        public int RestaurantID { get; set; }

    }
}
