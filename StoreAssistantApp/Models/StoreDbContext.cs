using Microsoft.EntityFrameworkCore;

namespace StoreAssistantApp.Models
{
    public class StoreDbContext:DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options):base(options)
        {

        }
        public DbSet<Nomenclatures> Nomenclatures { get; set; }
        public DbSet<Warehouses> Warehouses { get; set; }
        public DbSet<MoveHistory> MoveHistories { get; set; }
        public DbSet<StoreHouse> StoreHouses { get; set; }
    }
}
