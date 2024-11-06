using answer.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace answer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().ToTable("Groups");
            modelBuilder.Entity<Item>().ToTable("Items");

            modelBuilder.Entity<Group>().HasKey(g => g.GroupID);
            modelBuilder.Entity<Item>().HasKey(i => i.ItemID);
            modelBuilder.Entity<Item>()
                .HasOne<Group>()
                .WithMany()
                .HasForeignKey(i => i.GroupID)
                .HasPrincipalKey(g => g.GroupID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
