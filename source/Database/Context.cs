using AlphaCentauri.Domain;
using Microsoft.EntityFrameworkCore;

namespace AlphaCentauri.Database;

public sealed class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
}
