using BookingRoomUniversity.Core.Base;
using BoookingRoomUniversity.Assignment.Repositories.Enums;
using System;

namespace BoookingRoomUniversity.Assignment.Repositories.Entities
{
    public partial class BookingDetail : BaseEntity
    {
        public int BookingDetailId { get; set; }
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public int SlotId { get; set; }
        public string Reason { get; set; }
        public DateOnly BookingDate { get; set; }
        public ApprovalStatus Status { get; set; }

        public virtual Booking Booking { get; set; }

        public virtual Room Room { get; set; }
        public virtual ICollection<BookingCancel> BookingCancels { get; set; }
    }
}
