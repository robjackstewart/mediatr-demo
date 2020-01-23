using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class MediatRDemoDbContext : DbContext
    {
        protected MediatRDemoDbContext(DbContextOptions<MediatRDemoDbContext> options)
            : base(options) { }

        DbSet<Customer> Customers { get; set; }
        DbSet<Callout> Callouts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(typeof(MediatRDemoDbContext).Assembly);
    }
}
