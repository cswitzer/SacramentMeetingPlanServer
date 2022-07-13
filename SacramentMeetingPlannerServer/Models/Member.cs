using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentMeetingPlannerServer.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string FullName { get; set; }
    }
}
