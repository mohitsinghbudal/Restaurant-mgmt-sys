using HotelManagementSystem.Interfaces.DatabaseConnection;
using HotelManagementSystem.Models.MenuItems;
using Dapper;
using HotelManagementSystem.Interfaces.TableInterface;

namespace HotelManagementSystem.DLL.MenuDLL
{
    public class MenuDLL
    {
        private readonly IDbConnectionFactory _dbConn;
        private readonly ITableDLL _tableDLL;

        public MenuDLL(IDbConnectionFactory dbConn, ITableDLL tableDLL)
        {
            _dbConn = dbConn;
            _tableDLL = tableDLL;
        }
        public async Task<int> CreateMenuItemAsync(Menu menu)
        {
            using var connection = _dbConn.CreateConnection();
            var sql = @"
            INSERT INTO Menu
            (ItemName, ItemDescription, CategoryId, SubCategoryId, ItemImage, ItemPrice, Unit, IsAvailable, CreatedBy, CreatedOn)
            VALUES
            (@ItemName, @ItemDescription, @CategoryId, @SubCategoryId, @ItemImage, @ItemPrice, @Unit, @IsAvailable, @CreatedBy, @CreatedOn);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";
            var menuId = await connection.ExecuteScalarAsync<int>(sql, menu);
            return menuId;
        }
        public async Task<Menu> GetMenuItemByIdAsync(int menuId)
        {
            using var connection = _dbConn.CreateConnection();
            string sql = @"SELECT * FROM Menu WHERE MenuId = @MenuId";
            var menu = await connection.QuerySingleOrDefaultAsync<Menu>(sql, new { MenuId = menuId });
            if (menu == null)
            {
                throw new Exception("Menu item not found.");
            }
            return menu;
        }
        public async Task<IEnumerable<Menu>> UpdateMenuAsync()
        {
            using var connection = _dbConn.CreateConnection();
            string sql = @"ALTER TABLE MenuItems insert";
            var menu = await connection.QueryAsync<Menu>(sql);
            return menu;
        }
    }
}
