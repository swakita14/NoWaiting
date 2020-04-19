using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NowaiterApi.Interfaces;
using NowaiterApi.Models;

namespace NowaiterApi.DAL.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly NowaiterContext _context;

        public StatusRepository(NowaiterContext context)
        {
            _context = context;
        }

        public Status AddStatus(Status newStatus)
        {
            _context.Statuses.Add(newStatus);
            _context.SaveChanges();
            return newStatus;
        }

        public void EditInStore(Status status)
        {
            _context.Entry(status).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Status GetRestaurantStatusById(int id)
        {
            Status currentStatus = _context.Statuses.FirstOrDefault(x => x.RestaurantId == id);

            if (currentStatus == null) return null;

            return currentStatus;
        }

        public void EditStatus(Status status)
        {
            _context.Entry(status).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public bool IsEmptyDriveThru(int restaurantId)
        {
            return GetRestaurantStatusById(restaurantId).DriveThru == 0;
        }

        public bool IsEmptyInStore(int restaurantId)
        {
            return GetRestaurantStatusById(restaurantId).InStore == 0;
        }

        public int AddDriveThru(int restaurantId)
        {
            Status changeStatus = GetRestaurantStatusById(restaurantId);

            changeStatus.DriveThru += 1;

            EditStatus(changeStatus);
            
            return changeStatus.DriveThru;
        }

        public int AddInStore(int restaurantId)
        {
            Status changeStatus = GetRestaurantStatusById(restaurantId);

            changeStatus.InStore += 1;

            EditStatus(changeStatus);

            return changeStatus.InStore;
        }

        public int LeftDriveThru(int restaurantId)
        {
            if (IsEmptyDriveThru(restaurantId))
            {
                throw new ArgumentException("Drive-thru is already empty");
            }
            Status changeStatus = GetRestaurantStatusById(restaurantId);

            changeStatus.DriveThru -= 1;

            EditStatus(changeStatus);

            return changeStatus.DriveThru;
        }

        public int LeftInStore(int restaurantId)
        {
            if (IsEmptyInStore(restaurantId))
            {
                throw new ArgumentException("Drive-thru is already empty");
            }
            Status changeStatus = GetRestaurantStatusById(restaurantId);

            changeStatus.InStore -= 1;

            EditStatus(changeStatus);

            return changeStatus.InStore;
        }

    }
}
