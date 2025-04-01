using System;
using System.Collections.Generic;
using BookingRoomUniversity.Core.Base;
using BoookingRoomUniversity.Assignment.Repositories.Enums;

namespace BoookingRoomUniversity.Assignment.Repositories.Entities;

public partial class Room : BaseEntity
{
    public int RoomId { get; set; }


    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public RoomStatus Status { get; set; }
    public int CampusId { get; set; }
    public virtual Campus Campus { get; set; } = null!;

    public virtual ICollection<BookingDetail> BookingDetails { get; set; }
    public ICollection<RoomDetail> RoomDetails { get; set; }
}
