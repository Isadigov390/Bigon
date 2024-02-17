using Bigon.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.DataAccessLayer.Confugrations
{


    class ContectPostEntityTypeConfugrations : IEntityTypeConfiguration<ContactPost>
    {
        public void Configure(EntityTypeBuilder<ContactPost> builder)
        {
            builder.Property(m => m.FullName).HasColumnType("nvarchar").IsRequired().HasMaxLength(100);
            builder.Property(m => m.Email).HasColumnType("nvarchar").IsRequired().HasMaxLength(100);
            builder.Property(m => m.Subject).HasColumnType("nvarchar").IsRequired().HasMaxLength(100);
            builder.Property(m => m.Message).HasColumnType("nvarchar(max)").IsRequired().HasMaxLength(100);
            builder.Property(m => m.Answer).HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.AnsweredAt).HasColumnType("datetime");
            builder.Property(m => m.AnsweredBy).HasColumnType("int");

            builder.ConfigureAuditable();

            builder.HasKey(m => m.Id);
            builder.ToTable("ContactPosts");
        }
    }
}   
