namespace Church_Management_Service.Models
{
    public class Membership
    {
        public string MembershipId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Branch { get; set; }
        public string Email { get; set; }
        public string Dob { get; set; }
        public string Country { get; set; }
        public bool IsMember { get; set; }
        public string DateRegistered { get; set; }
    }
}
