using System.ComponentModel.DataAnnotations;

namespace Church_Management_Service.Models.RequestModel
{
    public class MembershipRequest
    {
       
        public string firstName { get; set; }

       
        public string lastName { get; set; }

       
        public string phoneNumber { get; set; }
        public string email { get; set; }

       
        public string dob { get; set; }
        public string country { get; set; }
        public string branch { get; set; }


        public bool isMember { get; set; }
    }
}
