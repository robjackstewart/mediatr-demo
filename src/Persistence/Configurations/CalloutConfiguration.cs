using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CalloutConfiguration : IEntityTypeConfiguration<Callout>
    {
        public void Configure(EntityTypeBuilder<Callout> builder)
        {
            builder.HasKey(e => e.CalloutId);

            builder.HasOne(e => e.Customer)
                .WithMany(c => c.Callouts)
                .HasForeignKey(e => e.CustomerId)
                .HasConstraintName("FK_Callouts_Customer");
        }
    }
}
