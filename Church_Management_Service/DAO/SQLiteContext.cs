using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;

namespace Church_Management_Service.DAO
{
    public class SQLiteContext
    {
        private readonly IConfiguration configuration;

        public SQLiteContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected IDbConnection Connection()
        {
            return new SqliteConnection(configuration.GetConnectionString("SQLiteConnection"));
        }

        public async Task Init()
        {
            using var _connection = Connection();

            await _initMemberships();
            await _initAttendance();

            async Task _initMemberships()
            {
                var sql = @"CREATE TABLE IF NOT EXISTS Membership (
                            MembershipId TEXT PRIMARY KEY,
                            FirstName TEXT,
                            LastName TEXT,
                            PhoneNumber TEXT,
                            Email TEXT,
                            Dob TEXT,
                            Branch TEXT,
                            DateRegistered TEXT,
                            Country TEXT,
                            IsMember);";

                await _connection.ExecuteAsync(sql);
            }

            async Task _initAttendance()
            {
                var sql = @"CREATE TABLE IF NOT EXISTS Attendances(
                            AttendanceId INT IDENTITY(1,1) ,
                            MembershipId TEXT,
                            IsPresnt INT,
                            ServiceDate TEXT, 
                            Branch TEXT,
                            FOREIGN KEY (MembershipId) REFERENCES Membership(MembershipId));";

                await _connection.ExecuteAsync(sql);

            }
        }
    }
}
