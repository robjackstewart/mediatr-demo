using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class MediatRDemoDbContextFactory : DesignTimeDbContextFactoryBase<MediatRDemoDbContext>
    {
        protected override MediatRDemoDbContext CreateNewInstance(DbContextOptions<MediatRDemoDbContext> options)
            => new MediatRDemoDbContext(options);
    }
}
