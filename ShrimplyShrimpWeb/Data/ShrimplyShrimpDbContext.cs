using Microsoft.EntityFrameworkCore;
using ShrimplyShrimpWeb.Models;

namespace ShrimplyShrimpWeb.Data
{
    public class ShrimplyShrimpDbContext : DbContext
    {
        public ShrimplyShrimpDbContext(DbContextOptions<ShrimplyShrimpDbContext> options) : base(options)
        {

        }
        public DbSet<Shrimp> Shrimps { get; set; }
    }
}
