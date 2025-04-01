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
        Active,
        InActive,
        Unavailable
    }

    public enum ApprovalStatus
    {
        Approved,
        Rejected
    }
}
