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
        public int departmentId { get; set; }
        [Required]
        public string category { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public int userOpenId { get; set; }
        [Required]
        public int? userCollectId { get; set; }
        public int? userProcessId { get; set; }
        [Required]
        public bool isBase { get; set; }
        public int? baseTicketId { get; set; }
        public string? flag { get; set; }

    }
}
