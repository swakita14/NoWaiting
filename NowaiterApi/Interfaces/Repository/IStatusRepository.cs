using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NowaiterApi.Models;

namespace NowaiterApi.Interfaces
{
    public interface IStatusRepository
    {

         Status AddStatus(Status newStatus);
         void EditInStore(Status status);

         Status GetRestaurantStatusById(int id);

         void EditStatus(Status status);
         bool EmptyDriveThru(int id);

         bool EmptyInStore(int id);
    }
}
