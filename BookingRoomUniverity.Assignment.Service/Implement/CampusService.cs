using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoookingRoomUniversity.Assignment.Repositories.Data;
using BoookingRoomUniversity.Assignment.Repositories.Entities;

namespace BookingRoomUniverity.Assignment.Service.Implement
{
    public class CampusService
    {
        private IUnitOfWork _unitOfWork;

        public CampusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  async Task CreateCampus(Campus obj)
        {
            _unitOfWork.Repository<Campus>().Create(obj);
          await  _unitOfWork.SaveChangesAsync();
        }

        public  async Task DeleteCampus(Campus obj)
        {
            _unitOfWork.Repository<Campus>().Delete(obj);
          await  _unitOfWork.SaveChangesAsync();

        }

        public List<Campus> getAllCampus()
        {
            return _unitOfWork.Repository<Campus>().Entities.ToList();
        }

        public  async Task UpdateCampus(Campus obj)
        {
            _unitOfWork.Repository<Campus>().Update(obj);
            await _unitOfWork.SaveChangesAsync();

        }
    }
}
