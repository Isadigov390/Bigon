using Bigon.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.DataAccessLayer.Confugrations
{
    class CategoryEntityTypeConfugration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.Property(m => m.Id).IsRequired().HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.ParentId).HasColumnType("int");
            builder.Property(m => m.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(300);
                
            builder.ConfigureAuditable();

            builder.HasKey(m => m.Id);
            builder.ToTable("Categories");


            builder.HasOne<Category>()
                .WithMany()
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
