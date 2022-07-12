namespace SacramentMeetingPlannerServer.Models
{
    public class SacramentMeetingPlan
    {
        // primary key
        public int SacramentMeetingPlanId { get; set; }
        
        // foreign keys (to avoid cascade delete)
        public int OpeningHymnId { get; set; }
        public int SacramentHymnId { get; set; }
        public int? IntermediateHymnId { get; set; }
        public int ClosingHymnId { get; set; }
        public int ConductingLeaderId { get; set; }
        public int OpeningPrayerId { get; set; }
        public int SacramentPrayerId { get; set; }
        public int ClosingPrayerId { get; set; }


        public DateTime Time { get; set; }

        // navigation properties
        public Member ConductingLeader { get; set; }
        public Member OpeningPrayer { get; set; }
        public Member SacramentPrayer { get; set; }
        public Member ClosingPrayer { get; set; }
        public Hymn OpeningHymn { get; set; }
        public Hymn SacramentHymn { get; set; }
        public Hymn? IntermediateHymn { get; set; }
        public Hymn ClosingHymn { get; set; }
        public ICollection<Speaker> Speakers { get; set; }
    }
}
