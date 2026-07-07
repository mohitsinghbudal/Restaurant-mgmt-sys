using HotelManagementSystem.Interfaces.Inventory;
using HotelManagementSystem.Models.Inventory;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers.InventoryController
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        // GET: api/Inventory
        [HttpGet]
        public async Task<IActionResult> GetInventoryItems()
        {
            var inventoryItems = await _inventoryService.GetInventoryItemsAsync();

            return Ok(new
            {
                message = "Success",
                items = inventoryItems
            });
        }

        // GET: api/Inventory/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventoryItemById(int id)
        {
            var inventoryItem = await _inventoryService.GetInventoryItemById(id);

            if (inventoryItem == null)
            {
                return NotFound(new
                {
                    message = "Inventory item not found."
                });
            }

            return Ok(new
            {
                message = "Success",
                item = inventoryItem
            });
        }

        // POST: api/Inventory
        [HttpPost]
        public async Task<IActionResult> AddInventoryItem([FromBody] InventoryItem inventoryItem)
        {
            var addedItem = await _inventoryService.AddInventoryItem(inventoryItem);

            return Ok(new
            {
                message = "Inventory item added successfully.",
                item = addedItem
            });
        }

        // PUT: api/Inventory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInventoryItem(int id, [FromBody] InventoryItem inventoryItem)
        {
            if (id != inventoryItem.InventoryItemId)
            {
                return BadRequest(new
                {
                    message = "InventoryItemId does not match route id."
                });
            }

            var rowsAffected = await _inventoryService.UpdateInventoryItem(inventoryItem);

            if (rowsAffected == 0)
            {
                return NotFound(new
                {
                    message = "Inventory item not found."
                });
            }

            return Ok(new
            {
                message = "Inventory item updated successfully."
            });
        }
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteInventoryItem(int id)
        //{
            

        //    return Ok(new
        //    {
        //        message = "Inventory item deleted successfully."
        //    });
        //}
    }
}