using Church_Management_Service.DAO;
using Church_Management_Service.Models;

namespace Church_Management_Service.Services.ServiceImplementation
{
    public class MembershipService : IMembershipService
    {
        private readonly IMembershipDAO _membershipDAO;

        public MembershipService(IMembershipDAO membershipDAO)
        {
            _membershipDAO = membershipDAO;
        }
        public async Task<Membership> GetMembershipById(string membershipId)
        {
            var getMembershipById = await _membershipDAO.GetMembershipById(membershipId);
            return getMembershipById;
        }

        public async Task<Membership> GetMembershipByPhoneNos(string phoneNos)
        {
           var getMembershipByPhoneNo = await _membershipDAO.GetMembershipByPhoneNos(phoneNos);
            return getMembershipByPhoneNo;
        }

        public async Task<List<Membership>> GetMemberships()
        {
            var getMembership = await _membershipDAO.GetMemberships();
            return getMembership;
        }

        public async Task<int> RegisterMembership(Membership member)
        {
            var res = await _membershipDAO.RegisterMembership(member);  
            return res;
        }
    }
}
