using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
