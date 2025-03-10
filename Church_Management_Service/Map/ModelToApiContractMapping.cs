using Church_Management_Service.Models;

namespace Student_Grading_Service_API.Map
{
    public static class ModelToApiContractMapping
    {

        public static Membership ToMembershipResponse(this Membership membership)
        {
           

            return new Membership
            {
                MembershipId = membership.MembershipId,
                FirstName = membership.FirstName,
                LastName = membership.LastName,
                Country = membership.Country,
                Dob = membership.Dob,
                Email = membership.Email,
                PhoneNumber = membership.PhoneNumber,
                IsMember = membership.IsMember,
            };
        }

       
    }
}
