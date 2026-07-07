using Dapper;
using HotelManagementSystem.Interfaces.DatabaseConnection;
using HotelManagementSystem.Interfaces.DinningInterface;
using HotelManagementSystem.Models.Dinning;
using System;
using System.Threading.Tasks;

namespace HotelManagementSystem.DLL.DinningDLL
{
    public class DinningDLL : IDinningDLL
    {
        private readonly IDbConnectionFactory _dbconn;

        public DinningDLL(IDbConnectionFactory dbconn)
        {
            _dbconn = dbconn;
        }

        public async Task<int> CreateDinningAsync(DinningModel dinning)
        {
            using var connection = _dbconn.CreateConnection();

            // 1. Corrected table name to DinningSessions
            // 2. Removed CustomerUserId to match your Model properties
            var sql = @"
                INSERT INTO DinningSessions (TableId, StartedAt, SessionStatus, UpdatedAt)
                OUTPUT INSERTED.SessionId
                VALUES (@TableId, GETUTCDATE(), @SessionStatus, NULL);";

            // Using QuerySingleAsync to cleanly pull back the newly generated primary key identity
            return await connection.QuerySingleAsync<int>(sql, dinning);
        }

        public async Task<DinningModel> GetDinningByIdAsync(int sessionId)
        {
            using var connection = _dbconn.CreateConnection();

            var sql = "SELECT * FROM DinningSessions WHERE SessionId = @SessionId;";
            var dinning = await connection.QuerySingleOrDefaultAsync<DinningModel>(sql, new { SessionId = sessionId });

            if (dinning == null)
            {
                throw new KeyNotFoundException($"Dining session with ID {sessionId} was not found.");
            }
            return dinning;
        }

        public async Task<int> EndDinningSessionAsync(DinningModel dinning)
        {
            using var connection = _dbconn.CreateConnection();

            // FIX: This must be an UPDATE statement targeting an existing SessionId record!
            var sql = @"
                UPDATE DinningSessions
                SET EndAt = GETUTCDATE(),
                    SessionStatus = @SessionStatus,
                    UpdatedAt = GETUTCDATE()
                WHERE SessionId = @SessionId;";

            // ExecuteAsync returns the count of affected rows (should be 1 if successful)
            return await connection.ExecuteAsync(sql, dinning);
        }

        public async Task<DinningModel> GetDinningBySessionId(int id)
        {
            using var connection = _dbconn.CreateConnection();

            string sql = @"SELECT * FROM DinningSessions WHERE SessionId = @SessionId;";

            return await connection.QuerySingleOrDefaultAsync<DinningModel>(sql, new { SessionId = id });
        }
    }
}