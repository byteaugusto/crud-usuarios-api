using Microsoft.EntityFrameworkCore;
using MinhaPrimeiraApi;

namespace MinhaPrimeiraApi.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; } = null!;
    }
}