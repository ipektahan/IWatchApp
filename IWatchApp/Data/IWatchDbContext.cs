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
    }
}
