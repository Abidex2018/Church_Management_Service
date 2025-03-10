using Church_Management_Service.Models;
using Dapper;
using static System.Net.Mime.MediaTypeNames;

namespace Church_Management_Service.DAO.Implementation
{
    public class AttendanceDAO : SQLiteContext, IAttendanceDAO
    {
        ILogger<AttendanceDAO> logger;
        public AttendanceDAO(IConfiguration configuration, ILogger<AttendanceDAO> logger) : base(configuration)
        {
            this.logger = logger;
        }
        public async Task<IEnumerable<Attendance>> GetAttendanceByBranch(string branch)
        {
            try
            {
                using (var conn = Connection())
                {
                    
                    var sql = $"SELECT MembershipId, AttendanceId,ServiceDate, IsPresnt, Branch FROM Attendances WHERE Branch = @branch;";
                    var attendance = await conn.QueryAsync<Attendance>(sql, new { branch = branch });

                    if (attendance != null)
                    {
                        return attendance;
                    }
                    return attendance ?? Enumerable.Empty<Attendance>();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> IsAttendanceExisting(string MembershipId, string ServiceDate)
        {
            try
            {
                using (var conn = Connection())
                {

                    var sql = $"SELECT MembershipId,ServiceDate, IsPresnt, Branch FROM Attendances WHERE MembershipId = @MembershipId  AND ServiceDate = @ServiceDate;";
                    var attendance = await conn.QueryFirstOrDefaultAsync<Attendance>(sql, new { MembershipId = MembershipId, ServiceDate = ServiceDate });

                    if (attendance != null)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Attendance>> GetAttendances()
        {
            try
            {

                using (var conn = Connection())
                {

                    var sql = $"SELECT MembershipId, AttendanceId,ServiceDate, IsPresnt, Branch FROM Attendances;";
                    var attendances = await conn.QueryAsync<Attendance>(sql);

                    if (attendances != null)
                    {
                        return attendances;
                    }
                    return attendances ?? Enumerable.Empty<Attendance>();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> MarkAttendance(Attendance attendance)
        {
            try
            {
                //var parameters = new DynamicParameters();
                //parameters.Add("@MembershipId", attendance.MembershipId);
                //parameters.Add("@IsPresnt", attendance.IsPresent);
                //parameters.Add("@Branch", attendance.Branch);
                //parameters.Add("@ServiceDate", attendance.ServiceDate);

                //Console.WriteLine("Dapper Parameters:");
                //foreach (var paramName in parameters.ParameterNames)
                //{
                //    Console.WriteLine($"{paramName}: {parameters.Get<object>(paramName)}");
                //}
                using (var conn = Connection())
                {
                   

                    var sql = "INSERT INTO Attendances(MembershipId, IsPresnt, Branch, ServiceDate) VALUES(@MembershipId, @IsPresnt, @Branch, @ServiceDate);";

                    var res = await conn.ExecuteAsync(sql, attendance);
                    return res;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
