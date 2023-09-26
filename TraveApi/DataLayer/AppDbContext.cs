using Microsoft.EntityFrameworkCore;
using TraveApi.Entity;

namespace TraveApi.DataLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Human> Humans { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Human>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Human>()
                .Property(e => e.Fullname)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Human>()
                .Property(e =>e.Travelprice)
                .IsRequired();
            modelBuilder.Entity<Human>()
                .Property(e => e.Age)
                .IsRequired();
            modelBuilder.Entity<Human>()
                .Property(e => e.Data)
                .HasDefaultValue(DateTime.UtcNow);
            modelBuilder.Entity<Human>()
                .Property(e => e.GroupId)
                .IsRequired();
            modelBuilder.Entity<Human>()
                .Property(e =>e.TravelData)
                .IsRequired();
                
            base.OnModelCreating(modelBuilder);
        }
    }
}
