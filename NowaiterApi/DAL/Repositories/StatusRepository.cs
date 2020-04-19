using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NowaiterApi.Interfaces.Repository;
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
        public bool IsEmptyDriveThru(Status currentStatus)
        {
            return currentStatus.DriveThru == 0;
        }

        public bool IsEmptyInStore(Status currentStatus)
        {
            return currentStatus.InStore == 0;
        }

        public int AddDriveThru(Status changeStatus)
        {
            changeStatus.DriveThru += 1;

            EditStatus(changeStatus);
            
            return changeStatus.DriveThru;
        }

        public int AddInStore(Status changeStatus)
        {
            changeStatus.InStore += 1;

            EditStatus(changeStatus);

            return changeStatus.InStore;
        }

        public int LeftDriveThru(Status changeStatus)
        {
            if (IsEmptyDriveThru(changeStatus))
            {
                throw new ArgumentException("Drive-thru is already empty");
            }
            changeStatus.DriveThru -= 1;

            EditStatus(changeStatus);

            return changeStatus.DriveThru;
        }

        public int LeftInStore(Status changeStatus)
        {
            if (IsEmptyInStore(changeStatus))
            {
                throw new ArgumentException("Drive-thru is already empty");
            }
            changeStatus.InStore -= 1;

            EditStatus(changeStatus);

            return changeStatus.InStore;
        }

    }
}
