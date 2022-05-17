using System.ComponentModel.DataAnnotations;

namespace Ticketer.Models
{
    public class Timing
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int ticketId { get; set; }
        [Required]
        public DateTime collectTime { get; set; }
        public DateTime processTime { get; set; }
        public DateTime solveTime { get; set; }
        public DateTime closeTime { get; set; }
        public DateTime pendingTime { get; set; }
        public DateTime suspendTime { get; set; }

    }
}
