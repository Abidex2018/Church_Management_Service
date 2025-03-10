namespace Church_Management_Service.Models
{
    public class Attendance
    {
        //public string attendanceId { get; set; }    
        public string MembershipId { get; set; }
        public string Branch { get; set; }
        public bool IsPresnt { get; set; }
        public string ServiceDate { get; set; }
    }
}
