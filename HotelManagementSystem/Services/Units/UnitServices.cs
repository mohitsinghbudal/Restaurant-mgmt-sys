using HotelManagementSystem.Interfaces.Units;
using HotelManagementSystem.Models.Units;

namespace HotelManagementSystem.Services.Units
{
    public class UnitServices : IUnitServices
    {
        private readonly IUnitDLL _unitDLL;

        public UnitServices(IUnitDLL unitDLL)
        {
            _unitDLL = unitDLL;
        }

        public async Task<IEnumerable<Unit>> GetAllUnitsAsync()
        {
            return await _unitDLL.GetAllUnitsAsync();
        }

        public async Task<int> AddUnitAsync(Unit unit)
        {
            return await _unitDLL.AddUnitAsync(unit);
        }

        public async Task<int> UpdateUnitAsync(Unit unit)
        {
            return await _unitDLL.UpdateUnitAsync(unit);
        }

        public async Task<int> DeleteUnitAsync(int unitId)
        {
            return await _unitDLL.DeleteUnitAsync(unitId);
        }
    }
}