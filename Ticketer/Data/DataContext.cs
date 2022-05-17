using Microsoft.EntityFrameworkCore;
using Ticketer.Models;

namespace Ticketer.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Ticket> Ticket { get; set; }

        public DbSet<Ticketer.Models.Department> Department { get; set; }

        public DbSet<Ticketer.Models.Timing> Timing { get; set; }
    }
}
