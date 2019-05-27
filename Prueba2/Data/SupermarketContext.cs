using Prueba2.Models;
using Microsoft.EntityFrameworkCore;

namespace Prueba2.Data
{
    public class SupermarketContext : DbContext
    {
        public SupermarketContext(DbContextOptions<SupermarketContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Item>(entity => 
            {
                entity.HasIndex(e => e.Code).IsUnique();
            });
        }
    }
}