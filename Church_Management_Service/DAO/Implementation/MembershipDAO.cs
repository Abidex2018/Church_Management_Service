using Church_Management_Service.Models;
using Dapper;

namespace Church_Management_Service.DAO.Implementation
{
    public class MembershipDAO : SQLiteContext, IMembershipDAO
    {
        ILogger<MembershipDAO> logger;
        public MembershipDAO(IConfiguration configuration, ILogger<MembershipDAO> logger) : base(configuration) 
        {
            this.logger = logger;
        }
        public async Task<Membership> GetMembershipById(string membershipId)
        {
            try
            {
                using (var conn = Connection())
                {
                    var sql = $"SELECT MembershipId, FirstName, LastName, PhoneNumber, Branch, Email FROM Membership WHERE MembershipId = @membershipId;";
                    var membership = await conn.QueryFirstOrDefaultAsync<Membership>(sql, new { membershipId = membershipId });
                    if (membership != null)
                    {
                        return membership;
                    }
                    return new Membership();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Membership> GetMembershipByPhoneNos(string phoneNos)
        {
            try
            {
                using (var conn = Connection())
                {
                    var sql = $"SELECT MembershipId, PhoneNumber, Branch FROM Membership WHERE PhoneNumber = @phoneNos;";
                    var membership = await conn.QueryFirstOrDefaultAsync<Membership>(sql, new { phoneNos = phoneNos });
                    if (membership != null)
                    {
                        return membership;
                    }
                    return new Membership();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Membership>> GetMemberships()
        {
            try
            {
                using (var conn = Connection())
                {

                    var sql = $"SELECT MembershipId, FirstName, LastName, PhoneNumber, Branch, Email, Dob, DateRegistered, Country, IsMember FROM Membership";
                    var memberships = await conn.QueryAsync<Membership>(sql);



                    if (memberships != null)
                    {
                        var ressultList = memberships.ToList();
                       
                        return ressultList;

                    }
                    return new List<Membership>();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> RegisterMembership(Membership member)
        {
            try
            {


                using (var conn = Connection())
                {

                     var sql = "INSERT INTO Membership(MembershipId, FirstName, LastName, PhoneNumber, Email, Dob, Branch, DateRegistered, Country, IsMember) VALUES(@MembershipId, @FirstName, @LastName, @PhoneNumber, @Email, @Dob, @Branch, @DateRegistered, @Country, @IsMember);";
                    //var sql = "INSERT INTO Membership(MembershipId, FirstName, LastName, PhoneNumber, Email, Dob, Branch, DateRegistered, Country) VALUES(@MembershipId, @FirstName, @LastName, @PhoneNumber, @Email, @Dob, @Branch, @DateRegistered, @Country);";

                    var res = await conn.ExecuteAsync(sql, member);
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
