using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentMeetingPlannerServer.Models
{
    public class SacramentMeetingPlan
    {
        // primary key
        public int SacramentMeetingPlanId { get; set; }

        // foreign keys (to avoid cascade delete)
        [ForeignKey("ConductingLeader")]
        public int ConductingLeaderId { get; set; }
        [ForeignKey("OpeningPrayer")]
        public int OpeningPrayerId { get; set; }
        [ForeignKey("SacramentPrayer")]
        public int SacramentPrayerId { get; set; }
        [ForeignKey("ClosingPrayer")]
        public int ClosingPrayerId { get; set; }
        [ForeignKey("OpeningHymn")]
        public int OpeningHymnId { get; set; }
        [ForeignKey("SacramentHymn")]
        public int SacramentHymnId { get; set; }
        [ForeignKey("IntermediateHymn")]
        public int? IntermediateHymnId { get; set; }
        [ForeignKey("ClosingHymn")]
        public int ClosingHymnId { get; set; }

        public DateTime MeetingTime { get; set; }

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
