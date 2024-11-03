using B1Task1.Models;
using Microsoft.EntityFrameworkCore;

namespace B1ask1.DataAccess
{
    public class RandomDataDbContext : DbContext
    {
        public DbSet<RandomDataEntry> RandomDataEntries { get; set; }
        public RandomDataDbContext(DbContextOptions<RandomDataDbContext> options)
            : base(options)
        {
        }
    }
}
