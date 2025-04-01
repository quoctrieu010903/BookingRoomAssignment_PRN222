using BookingRoomUniversity.Core.Base;
using System;
using System.Collections.Generic;

namespace BoookingRoomUniversity.Assignment.Repositories.Entities;

public partial class Campus : BaseEntity
{
    public int CampusId { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public virtual ICollection<Department> Departments { get; set; }

    public virtual ICollection<User> Users { get; set; }
    public virtual ICollection<Room> Rooms { get; set; }
}
