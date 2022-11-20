using Microsoft.EntityFrameworkCore;
namespace Api.User.Core.ContextSqlServerDB
{
    public class ContextSqlServerDB : DbContext
    {
        public ContextSqlServerDB(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Entities.User> User { get; set; } = null!;
    }
}
