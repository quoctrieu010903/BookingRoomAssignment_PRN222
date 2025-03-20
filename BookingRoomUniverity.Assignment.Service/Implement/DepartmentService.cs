using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingRoomUniverity.Assignment.Service.Interface;
using BoookingRoomUniversity.Assignment.Repositories.Data;
using BoookingRoomUniversity.Assignment.Repositories.Entities;

namespace BookingRoomUniverity.Assignment.Service.Implement
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public  async Task CreateDepartment(Department obj)
        {
            _unitOfWork.Repository<Department>().Create(obj);
            await _unitOfWork.SaveChangesAsync();

        }

        public  async Task DeleteDepartment(Department obj)
        {
            _unitOfWork.Repository<Department>().Delete(obj);
            await _unitOfWork.SaveChangesAsync();
        }

        public List<Department> getALLDepartment()
        {
            return _unitOfWork.Repository<Department>().Entities.ToList();
        }

        public  async Task UpdateDepartment(Department obj)
        {
            _unitOfWork.Repository<Department>().Update(obj);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
