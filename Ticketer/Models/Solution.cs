using System.ComponentModel.DataAnnotations;

namespace Ticketer.Models
{
    public class Solution
    {
        [Key]
        public int id { get; set; }
        public int ticketId { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        public string recommendations { get; set; }
        public string references { get; set; }
        public string links { get; set; }
    }
}
