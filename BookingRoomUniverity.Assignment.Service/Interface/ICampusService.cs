using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoookingRoomUniversity.Assignment.Repositories.Entities;

namespace BookingRoomUniverity.Assignment.Service.Interface
{
    public interface ICampusService
    {
        List<Campus> getAllCampus();
        Task CreateCampus(Campus obj);
        Task UpdateCampus(Campus obj);
        Task DeleteCampus(Campus obj);
    }
}
