namespace SacramentMeetingPlannerServer.Models
{
    public class SacramentMeetingPlan
    {
        public int SacramentMeetingPlanId { get; set; }
        public ICollection<Speaker> Speakers { get; set; }
    }
}
