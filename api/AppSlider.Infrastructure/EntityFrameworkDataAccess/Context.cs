namespace AppSlider.Infrastructure.EntityFrameworkDataAccess
{
    using Microsoft.EntityFrameworkCore;

    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Domain.Users.User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Users.User>()
                .ToTable("User");
        }
    }
}
