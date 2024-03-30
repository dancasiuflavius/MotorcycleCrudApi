using MotorcycleCrudApi.Motorcycles.Model;
using Microsoft.EntityFrameworkCore;

namespace MotorcycleCrudApi
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Motorcycle> Motorcycles { get; set; }
    }
}
