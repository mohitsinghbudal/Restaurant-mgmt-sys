using HotelManagementSystem.Interfaces.Inventory;
using HotelManagementSystem.Models.Inventory;

namespace HotelManagementSystem.Services.Inventory
{
    public class InventoryServices : IInventoryService
    {
        private readonly IInventoryDLL _inventoryDLL;

        public InventoryServices(IInventoryDLL inventoryDLL)
        {
            _inventoryDLL = inventoryDLL;
        }

        public async Task<IEnumerable<InventoryItem>> GetInventoryItemsAsync()
        {
            return await _inventoryDLL.GetInventoryItemAsync();
        }

        public async Task<InventoryItem?> GetInventoryItemById(int id)
        {
            return await _inventoryDLL.GetInventoryItemById(id);
        }

        public async Task<InventoryItem> AddInventoryItem(InventoryItem inventoryItem)
        {
            return await _inventoryDLL.AddInventoryItem(inventoryItem);
        }

        public async Task<int> UpdateInventoryItem(InventoryItem inventoryItem)
        {
            return await _inventoryDLL.UpdateInventoryItem(inventoryItem);
        }
    }
}