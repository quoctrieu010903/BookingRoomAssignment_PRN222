using BookingRoomUniversity.Core.Base;
using BoookingRoomUniversity.Assignment.Repositories.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoookingRoomUniversity.Assignment.Repositories.Entities
{
    public partial class RoomDetail : BaseEntity
    {
        public int RoomDetailId { get; set; }
        public int RoomId { get; set; }
        public int SlotId { get; set; }
        public virtual Slot Slot { get; set; }
        public virtual Room Room { get; set; }
    }
}
