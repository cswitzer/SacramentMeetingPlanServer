using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentMeetingPlannerServer.Models
{
    public class Speaker
    {
        public int SpeakerId { get; set; }
        public int MemberId { get; set; }
        public string Topic { get; set; }
        public Member Member { get; set; }
        public SacramentMeetingPlan SacramentMeetingPlan { get; set; }

    }
}
