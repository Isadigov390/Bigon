using Bigon.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.DataAccessLayer.Confugrations
{
    class BrandEntityTypeConfugration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(m => m.Id).IsRequired().HasColumnType("int").UseIdentityColumn(1,1);
            builder.Property(m => m.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(300);

            builder.ConfigureAuditable();

            builder.HasKey(m => m.Id);  
            builder.ToTable("Brands");

        }
    }
}
