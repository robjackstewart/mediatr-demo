using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IMediatRDemoDbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Callout> Callouts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
