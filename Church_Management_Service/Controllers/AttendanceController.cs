using Church_Management_Service.GenericResponse;
using Church_Management_Service.Models;
using Church_Management_Service.Models.RequestModel;
using Church_Management_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Church_Management_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly ILogger<IAttendanceService> _logger;
        private readonly IAttendanceService _attendanceService;
        private readonly IMembershipService _membershipService;

        public AttendanceController(IAttendanceService attendanceService,IMembershipService membershipService, ILogger<IAttendanceService> logger)
        {
            _attendanceService = attendanceService;
            _membershipService = membershipService;
            _logger = logger;
        }

        [HttpPost("MarkAttendance")]
        public async Task<ActionResult> MarkAttendance([FromBody] AttendanceRequest attendance)
        {
            try
            {
                var getMemberByPhoneNo = await _membershipService.GetMembershipByPhoneNos(attendance.phoneNumber);
                string message;

                if (getMemberByPhoneNo.MembershipId == null)
                {

                    message = "Member or NewComer Not registered";
                    return BadRequest(new ApiResponse<Attendance>(false, null, message));
                   

                }
                var attendanceRequest = new Attendance
                {
                    MembershipId = getMemberByPhoneNo.MembershipId,
                    Branch = getMemberByPhoneNo.Branch,
                    IsPresnt = true,
                    ServiceDate = DateTime.UtcNow.ToShortDateString(),

                };
                var IsAttendanceExisting = await _attendanceService.IsAttendanceExisting(attendanceRequest.MembershipId, attendanceRequest.ServiceDate);
                if (IsAttendanceExisting)
                {
                    message = "Today's Attendance Already Exist";
                    return BadRequest(new ApiResponse<Attendance>(false, null, message));

                }
                var res = await _attendanceService.MarkAttendance(attendanceRequest);
                if (res == 0)
                {
                    message = "An Error occur, Please try again later";
                    return BadRequest(new ApiResponse<Attendance>(false, null, message));
                   
                }
                message = "Attendance Submitted Successfully";
                return Ok(new ApiResponse<Attendance>(true, attendanceRequest, message));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAttendance()
        {
            var getAttendances = await _attendanceService.GetAttendances();
            string message;
            if (!getAttendances.Any())
            {
                message = "No attendance exist";
                return BadRequest(new ApiResponseList<Attendance>(false, null, message));
            }

            message = "Attendances pulled Successfully";
            var attendances = getAttendances.ToList();
            return Ok(new ApiResponseList<Attendance>(true, attendances, message));
        }
    }
}
