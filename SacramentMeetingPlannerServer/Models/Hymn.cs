using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlannerServer.Models
{
    public class Hymn
    {
        [Key]
        public int HymnNumber { get; set; }
        public string HymnTitle { get; set; }
        public string HymnType { get; set; }
    }
}
