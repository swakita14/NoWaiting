using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NowaiterApi.Models;

namespace NowaiterApi.Interfaces
{
    interface IStatusRepository
    {
         void EditInStore(Status status);

         Status GetRestaurantStatusById(int id);

         void EditStatus(Status status);
         bool EmptyDriveThru(int id);

         bool EmptyInStore(int id);
    }
}
