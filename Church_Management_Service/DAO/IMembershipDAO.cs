using Church_Management_Service.Models;

namespace Church_Management_Service.DAO
{
    public interface IMembershipDAO
    {
        Task<int> RegisterMembership(Membership member);
        Task<List<Membership>> GetMemberships();
        Task<Membership> GetMembershipById(string studentGradeId);
        Task<Membership> GetMembershipByPhoneNos(string phoneNos);
    }
}
