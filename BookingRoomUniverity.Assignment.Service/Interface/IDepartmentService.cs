using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoookingRoomUniversity.Assignment.Repositories.Entities;

namespace BookingRoomUniverity.Assignment.Service.Interface
{
    public interface IDepartmentService
    {
        List<Department> getALLDepartment();
        Task CreateDepartment(Department obj);
        Task UpdateDepartment(Department obj);
        Task DeleteDepartment(Department obj);
    }
}
