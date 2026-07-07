using Dapper;
using HotelManagementSystem.Interfaces.DatabaseConnection;
using HotelManagementSystem.Interfaces.Inventory;
using HotelManagementSystem.Models.Inventory;
using System.Data;

namespace HotelManagementSystem.DLL.InventoryDLL
{
    public class InventoryDLL : IInventoryDLL
    {
        private readonly IDbConnectionFactory _dbConn;
        public InventoryDLL (IDbConnectionFactory dbConn)
        {
            _dbConn = dbConn;
        }

        public async Task<IEnumerable<InventoryItem>> GetInventoryItemAsync()
        {
            using var conn = _dbConn.CreateConnection();
            string sql = @"SELECT * FROM INVENTORY";

            var result = await conn.QueryAsync<InventoryItem>(sql);
            return result;

        }
        public async Task<InventoryItem> AddInventoryItem(InventoryItem inventoryItem)
        {
            using var conn = _dbConn.CreateConnection();

            string sql = @"
        INSERT INTO Inventory
        (
            ItemId,
            UnitId,
            CurrentQuantity,
            MinimumQuantity,
            CostPrice,
            IsActive,
            CreatedBy,
            CreatedOn
        )
        OUTPUT INSERTED.*
        VALUES
        (
            @ItemId,
            @UnitId,
            @CurrentQuantity,
            @MinimumQuantity,
            @CostPrice,
            @IsActive,
            @CreatedBy,
            @CreatedOn
        );";

            return await conn.QuerySingleAsync<InventoryItem>(sql, inventoryItem);
        }
        public async Task<int> UpdateInventoryItem(InventoryItem inventoryItem)
        {
            using var conn = _dbConn.CreateConnection();

            string sql = @"
        UPDATE Inventory
        SET
            ItemId = @ItemId,
            UnitId = @UnitId,
            CurrentQuantity = @CurrentQuantity,
            MinimumQuantity = @MinimumQuantity,
            CostPrice = @CostPrice,
            UpdatedBy = @UpdatedBy,
            UpdatedOn = @UpdatedOn
        WHERE InventoryItemId = @InventoryItemId;";

            return await conn.ExecuteAsync(sql, inventoryItem);
        }
        public async Task<InventoryItem?> GetInventoryItemById(int id)
        {
            using var conn = _dbConn.CreateConnection();

            string sql = @"
        SELECT *
        FROM Inventory
        WHERE InventoryItemId = @Id
          AND IsActive = 1;";

            return await conn.QueryFirstOrDefaultAsync<InventoryItem>(
                sql,
                new { Id = id });
        }
    }
}
