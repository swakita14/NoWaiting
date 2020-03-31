using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NowaiterApi.Models;

namespace NowaiterApi.Interfaces
{
    interface IStatusRepository
    {
        Status GetRestaurantStatusById(int id);

        void EditDriveIn(Restaurant restaurant);

        void EditInStore(Restaurant restaurant);

        void NewCustomer();

        void LeftRestaurant();
    }
}
