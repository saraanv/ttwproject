using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WTTAPI.Models
{
    public class PresenceDetail
    {
        [Key]
        public int PresenceId { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string Date { get; set; } = "";


        [Column(TypeName = "nvarchar(100)")]
        public string Arrival { get; set; } = "";


        [Column(TypeName = "nvarchar(100)")]
        public string Exit { get; set; } = "";
    }
}
