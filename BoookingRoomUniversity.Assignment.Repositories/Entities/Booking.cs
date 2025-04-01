using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BookingRoomUniversity.Core.Base;
using BoookingRoomUniversity.Assignment.Repositories.Enums;

namespace BoookingRoomUniversity.Assignment.Repositories.Entities;

public partial class Booking : BaseEntity
{
    public int BookingId { get; set; }

    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
    public string Reason { get; set; }
    public BookingStatus Status { get; set; }

    public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    public virtual ICollection<BookingCancel> BookingCancels { get; set; }

}
