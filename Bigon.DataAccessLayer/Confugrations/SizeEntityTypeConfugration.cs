using Bigon.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.DataAccessLayer.Confugrations
{
    class SizeEntityTypeConfugration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.Property(x => x.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(300).IsRequired();
            builder.Property(x => x.SmallName).HasColumnType("varchar").HasMaxLength(300).IsRequired();


            builder.ConfigureAuditable();

            builder.HasKey(x => x.Id);
            builder.ToTable("Sizes");
        }
    }
}
