using HotelManagementSystem.Models.Units;

namespace HotelManagementSystem.Interfaces.Units
{
    public interface IUnitDLL
    {
        Task<IEnumerable<Unit>> GetAllUnitsAsync();

        Task<int> AddUnitAsync(Unit unit);  

        Task<int> UpdateUnitAsync(Unit unit);

        Task<int> DeleteUnitAsync(int unitId);
    }

    public interface IUnitServices
    {
        Task<IEnumerable<Unit>> GetAllUnitsAsync();

        Task<int> AddUnitAsync(Unit unit);

        Task<int> UpdateUnitAsync(Unit unit);

        Task<int> DeleteUnitAsync(int unitId);
    }
}