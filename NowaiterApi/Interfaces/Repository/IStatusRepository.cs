using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NowaiterApi.Models;

namespace NowaiterApi.Interfaces.Repository
{
    public interface IStatusRepository
    {

         Status AddStatus(Status newStatus);
         void EditInStore(Status status);

         Status GetRestaurantStatusById(int id);

         void EditStatus(Status status);
    }
}
