using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingRoomUniversity.Core.Base
{
    public class BaseEntity
    {
        public DateTimeOffset? CreatedTime { get; set; }

        public DateTimeOffset? UpdatedTime { get; set; }

        public DateTimeOffset? DeleteTime { get; set; }

    }
}
