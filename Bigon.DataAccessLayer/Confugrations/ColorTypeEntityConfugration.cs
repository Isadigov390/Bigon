using Bigon.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bigon.DataAccessLayer.Confugrations
{
    class ColorTypeEntityConfugration : IEntityTypeConfiguration<Color>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Color> builder)
        {
            builder.Property(m=>m.Id).HasColumnType("int").UseIdentityColumn(1,1);
            builder.Property(m=>m.Name).HasColumnType("nvarchar").HasMaxLength(300).IsRequired();
            builder.Property(m=>m.HexCode).HasColumnType("varchar").HasMaxLength(300).IsRequired();

            builder.ConfigureAuditable();

            builder.HasKey(x => x.Id);
            builder.ToTable("Colors");
        }
    }
}
