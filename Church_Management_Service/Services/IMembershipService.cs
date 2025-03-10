using Church_Management_Service.Models;

namespace Church_Management_Service.Services
{
    public interface IMembershipService
    {
        Task<int> RegisterMembership(Membership member);
        Task<List<Membership>> GetMemberships();
        Task<Membership> GetMembershipById(string membershipId);
        Task<Membership> GetMembershipByPhoneNos(string phoneNos);
    }
}
