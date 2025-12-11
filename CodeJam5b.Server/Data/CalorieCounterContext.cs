using Microsoft.EntityFrameworkCore;
using CodeJam5b.Models;

namespace CodeJam5b.Server.Data
{
    public class CalorieCounterContext : DbContext
    {
        public CalorieCounterContext(DbContextOptions<CalorieCounterContext> options)
            : base(options)
        {
        }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Progress> Progress { get; set; }
    
    }
}
