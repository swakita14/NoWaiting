using System;
using System.Collections.Generic;
using System.Linq;
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

        public void EditInStore(Status status)
        {
            _context.Entry(status).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Status GetRestaurantStatusById(int id)
        {
            return _context.Statuses.FirstOrDefault(x => x.RestaurantID == id);
        }

        public void EditStatus(Status status)
        {
            _context.Entry(status).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public bool EmptyDriveThru(int id)
        {
            return _context.Statuses.FirstOrDefault(x => x.RestaurantID == id).Drive_Thru == 0;
        }

        public bool EmptyInStore(int id)
        {
            return _context.Statuses.FirstOrDefault(x => x.RestaurantID == id).In_Store == 0;
        }

    }
}
