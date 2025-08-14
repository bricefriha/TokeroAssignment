

using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

namespace WebAPI.Core.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {

    }
    public DbSet<Order> Orders { get; set; }
    public DbSet<DcaSetup> Setups { get; set; }
    public DbSet<UserData> Data { get; set; }
    public DbSet<Balance> Balances { get; set; }
    public DbSet<TokenShare> TokenShares { get; set; }
}
