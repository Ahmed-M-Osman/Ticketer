using System.ComponentModel.DataAnnotations;

namespace Ticketer.Models
{
    public class Ticket
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public string departmentId { get; set; }
        [Required]
        public string category { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public string userOpenId { get; set; }
        [Required]
        public string? userCollectId { get; set; }
        public string? userProcessId { get; set; }
        [Required]
        public bool isBase { get; set; }
        public string? baseTicketId { get; set; }
        public string? flag { get; set; }

    }
}
