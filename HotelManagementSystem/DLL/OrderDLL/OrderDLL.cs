using HotelManagementSystem.Interfaces.DatabaseConnection;
using HotelManagementSystem.Models.Order;
using Dapper;


namespace HotelManagementSystem.DLL.OrderDLL
{
    public class OrderDLL
    {
        private readonly IDbConnectionFactory _dbConn;

        public OrderDLL(IDbConnectionFactory dbConn)
        {
            _dbConn = dbConn;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            using var conn = _dbConn.CreateConnection();
            string sql = @"SELECT * FROM Orders WHERE OrderId = @OrderId";

            return conn.QueryFirstOrDefault<Order>(sql, new { OrderId = id });
        }
        public async Task<int> UpdateOrderAsync(Order order)
        {
            using var conn = _dbConn.CreateConnection();

            string sql = @"
                UPDATE Orders
                SET
                    OrderStatus = @OrderStatus,
                    Description = @Description,
                    UpdatedAt = GETUTCDATE(),
                    UpdatedBy = @UpdatedBy
                WHERE OrderId = @OrderId
                AND IsActive = 1;";

            return await conn.ExecuteAsync(sql, order);
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            using var conn = _dbConn.CreateConnection();

            string sql = @"
        INSERT INTO Orders
        (
            DiningSessionId,
            OrderStatus,
            Description,
            CreatedAt,
            UpdatedAt,
            CompletedAt,
            CreatedBy,
            UpdatedBy,
            IsActive
        )
        OUTPUT INSERTED.*
        VALUES
        (
            @DiningSessionId,
            @OrderStatus,
            @Description,
            @CreatedAt,
            @UpdatedAt,
            @CompletedAt,
            @CreatedBy,
            @UpdatedBy,
            @IsActive
        );";

            return await conn.QueryFirstOrDefaultAsync<Order>(sql, order);
        }
    }
}
