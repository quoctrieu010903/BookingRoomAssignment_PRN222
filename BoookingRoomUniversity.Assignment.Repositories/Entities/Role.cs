using BookingRoomUniversity.Core.Base;
using System;
using System.Collections.Generic;

namespace BoookingRoomUniversity.Assignment.Repositories.Entities;

public partial class Role : BaseEntity
{
    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
