

using Church_Management_Service.Models;
using Church_Management_Service.Models.RequestModel;

namespace Student_Grading_Service_API.Map
{
    public static class ApiContractToModelMapping
    {

        public static Membership ToMemberships(this MembershipRequest membership)
        {
            string uniqueMembershipID = Guid.NewGuid().ToString("N").Substring(0, 5);

            return new Membership
            {
                MembershipId = uniqueMembershipID,
                FirstName = membership.firstName,
                LastName = membership.lastName,
                Country = membership.country,
                Dob = membership.dob,
                Email = membership.email,
                PhoneNumber = membership.phoneNumber,
                IsMember = membership.isMember,
                Branch = membership.branch,
                DateRegistered = DateTime.UtcNow.ToString(),
            };
        }

        //public static Membership ToMembership(this MembershipRequest membership)
        //{
            

        //    return new Membership
        //    {
        //        //membershipId = membership.,
        //        firstName = membership.firstName,
        //        lastName = membership.lastName,
        //        country = membership.country,
        //        dob = membership.dob,
        //        email = membership.email,
        //        phoneNumber = membership.phoneNumber,
        //        isMember = membership.isMember,
        //        dateRegister = DateTime.UtcNow.ToString()
        //    };
        //}

    }
}
