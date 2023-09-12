using Microsoft.EntityFrameworkCore;
using IWatchApp.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace IWatchApp.Data
{
    public class IWatchDbContext : DbContext
    {
        public IWatchDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Item> Items { get; set; }
        public DbSet<VideoTypes> Videos { get; set; }

        public DbSet<URL> URLs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<URL>()
                .HasOne(url => url.Item)
                .WithMany(item => item.URLs)
                .HasForeignKey(url => url.ID);
        }
    }
}
