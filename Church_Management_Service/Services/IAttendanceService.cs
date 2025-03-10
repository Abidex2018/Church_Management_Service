using Church_Management_Service.Models;

namespace Church_Management_Service.Services
{
    public interface IAttendanceService
    {
        Task<IEnumerable<Attendance>> GetAttendances();
        Task<bool> IsAttendanceExisting(string membershipId, string serviceDate);
        Task<int> MarkAttendance(Attendance attendance);
        Task<IEnumerable<Attendance>> GetAttendanceByBranch(string branch);
    }
}
