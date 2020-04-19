using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NowaiterApi.Models;

namespace NowaiterApi.Interfaces.Service
{
    public interface IAvailabilityService
    {
        bool IsEmptyDriveThru(Status currentStatus);

        bool IsEmptyInStore(Status currentStatus);

        int AddDriveThru(Status changeStatus);

        int AddInStore(Status changeStatus);

        int LeftDriveThru(Status changeStatus);

        int LeftInStore(Status changeStatus);
    }
}
