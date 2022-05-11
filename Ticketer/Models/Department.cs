using System.ComponentModel.DataAnnotations;

namespace Ticketer.Models
{
    public class Department
    {
        [Key]
        [Required]
        public string id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string leadId { get; set; }
    }
}
