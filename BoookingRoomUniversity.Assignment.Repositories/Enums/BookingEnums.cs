using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoookingRoomUniversity.Assignment.Repositories.Enums
{
    public enum BookingStatus
    {
        Pending,
        Approved,
        Rejected,
        Completed,
        Cancelled
    }
        public enum RoomStatus
    {
        Available,
        Booked,
        Maintenance,
        Closed
    }
    public enum DepartmentStatus
    {
        Inactive = 0,
        Active = 1,
        Pending = 2,
        Archived = 3
    }
}
