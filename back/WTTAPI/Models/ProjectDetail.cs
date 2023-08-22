
using System.ComponentModel.DataAnnotations;

namespace WTTAPI.Models
{
    public class ProjectDetail
    {
        [Key]
        public int PID { get; set; }
        public string Name { get; set; }
        public string Requester { get; set; }


    }
}
