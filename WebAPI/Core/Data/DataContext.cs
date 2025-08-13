

using Microsoft.EntityFrameworkCore;

namespace WebAPI.Core.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {

    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<DcaSetup> Setups { get; set; }

    
}
