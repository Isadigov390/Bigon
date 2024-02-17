using Bigon.Domain;
using Bigon.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.DataAccessLayer.Confugrations
{
    static class EntityTypeConfugrationHelper
    {
        public static EntityTypeBuilder<T> ConfigureAuditable<T>(this EntityTypeBuilder<T> builder)
            where T : class, IAuditableEntity
        {
            builder.Property(m => m.CreatedAt).HasColumnType("datetime");
            builder.Property(m => m.CreatedBy).HasColumnType("int");
            builder.Property(m => m.DeletedAt).HasColumnType("datetime");
            builder.Property(m => m.DeletedBy).HasColumnType("int");
            builder.Property(m => m.LastModifiedAt).HasColumnType("datetime");
            builder.Property(m => m.LastModifiedBy).HasColumnType("int");
            return builder;
        }
    }
}
