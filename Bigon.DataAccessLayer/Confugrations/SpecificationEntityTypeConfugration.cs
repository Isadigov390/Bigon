using Bigon.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.DataAccessLayer.Confugrations
{
    class SpecificationEntityTypeConfugration : IEntityTypeConfiguration<Specification>
    {
        public void Configure(EntityTypeBuilder<Specification> builder)
        {

            builder.Property(x => x.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(300).IsRequired();

            builder.ConfigureAuditable();

            builder.HasKey(x => x.Id);
            builder.ToTable("Specifications");
        }
    }
}
