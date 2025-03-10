using Church_Management_Service.GenericResponse;
using Church_Management_Service.Models.RequestModel;
using Church_Management_Service.Models;
using Church_Management_Service.Services;
using Church_Management_Service.Services.ServiceImplementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Grading_Service_API.Map;
using FluentValidation;

namespace Church_Management_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        private readonly ILogger<IMembershipService> _logger;
        private readonly IMembershipService _membershipService;
        private readonly IValidator<MembershipRequest> _validator;

        public MembershipController(IValidator<MembershipRequest> validator, IMembershipService membershipService, ILogger<IMembershipService> logger)
        {
            _membershipService = membershipService;
            _logger = logger;
            _validator = validator;
            
        }

        [HttpPost("RegisterMember")]
        public async Task<ActionResult> RegisterMember([FromBody] MembershipRequest membership)
        {
            
            try
            {
                var validationResult = await _validator.ValidateAsync(membership);
                string message;

                if (!validationResult.IsValid)
                {
                    message = "An Error occur, Please try again later";
                    return BadRequest(new ApiResponse<MembershipRequest>(false, null ,null, validationResult.Errors.Select(e=>e.ErrorMessage).ToArray()));
                }

                var createMember = membership.ToMemberships();

                var getMemberByPhoneNo = await _membershipService.GetMembershipByPhoneNos(createMember.PhoneNumber);
               

                if (getMemberByPhoneNo.PhoneNumber != null)
                {

                    message = "Member or NewComer Already Exist";
                    return BadRequest(new ApiResponse<Attendance>(false, null, message));


                }
                
                var res = await _membershipService.RegisterMembership(createMember);
                if (res == 0)
                {
                    message = "An Error occur, Please try again later";
                    return BadRequest(new ApiResponse<Attendance>(false, null, message));

                }
                message = "Member Or NewComer Registered Successfully";

                //Also Mark the
                var membershipResponseModel = createMember.ToMembershipResponse();
                return Ok(new ApiResponse<Membership>(true, membershipResponseModel, message));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<MembershipRequest>(false, membership, ex.Message));
            }
        }
    }
}
