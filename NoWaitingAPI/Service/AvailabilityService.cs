using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NowaiterApi.Interfaces.Repository;
using NowaiterApi.Interfaces.Service;
using NowaiterApi.Models;

namespace NowaiterApi.Service
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly IStatusRepository _statusRepository;

        public AvailabilityService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
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

            _statusRepository.EditStatus(changeStatus);

            return changeStatus.DriveThru;
        }

        public int AddInStore(Status changeStatus)
        {
            changeStatus.InStore += 1;

            _statusRepository.EditStatus(changeStatus);

            return changeStatus.InStore;
        }

        public int LeftDriveThru(Status changeStatus)
        {
            if (IsEmptyDriveThru(changeStatus))
            {
                throw new ArgumentException("Drive-thru is already empty");
            }
            changeStatus.DriveThru -= 1;

            _statusRepository.EditStatus(changeStatus);

            return changeStatus.DriveThru;
        }

        public int LeftInStore(Status changeStatus)
        {
            if (IsEmptyInStore(changeStatus))
            {
                throw new ArgumentException("Drive-thru is already empty");
            }
            changeStatus.InStore -= 1;

            _statusRepository.EditStatus(changeStatus);

            return changeStatus.InStore;
        }
    }
}
