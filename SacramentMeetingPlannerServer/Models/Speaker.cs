namespace SacramentMeetingPlannerServer.Models
{
    public class Speaker
    {
        public int SpeakerId { get; set; }
        public int SacramentMeetingPlanId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public SacramentMeetingPlan SacramentMeetingPlan { get; set; }

    }
}
