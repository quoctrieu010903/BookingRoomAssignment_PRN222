using BookingRoomUniversity.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoookingRoomUniversity.Assignment.Repositories.Entities
{
    public partial class Slot : BaseEntity
    {
        public int SLotId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ICollection<RoomDetail> RoomDetails { get; set; }

    }
}
