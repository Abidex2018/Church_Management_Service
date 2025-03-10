using Church_Management_Service.DAO;
using Church_Management_Service.Models;

namespace Church_Management_Service.Services.ServiceImplementation
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceDAO _attendanceDAO;
        public AttendanceService(IAttendanceDAO attendanceDAO)
        {
            _attendanceDAO = attendanceDAO;
        }
        public async Task<IEnumerable<Attendance>> GetAttendanceByBranch(string branch)
        {
            var getAttendancesNByBranch = await _attendanceDAO.GetAttendanceByBranch(branch);
            return getAttendancesNByBranch;
        }

        public async Task<bool> IsAttendanceExisting(string membershipId, string serviceDate)
        {
            var doesAttendanceExist = await _attendanceDAO.IsAttendanceExisting(membershipId, serviceDate);
            return doesAttendanceExist;
        }
        public async Task<IEnumerable<Attendance>> GetAttendances()
        {
            var getAttendances = await _attendanceDAO.GetAttendances();
            return getAttendances;
        }

        public async Task<int> MarkAttendance(Attendance attendance)
        {
            var res = await _attendanceDAO.MarkAttendance(attendance);
            return res;
        }
    }
}
