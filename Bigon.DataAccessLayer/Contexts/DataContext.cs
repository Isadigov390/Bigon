using Bigon.Infrastructure;
using Bigon.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Bigon.DataAccessLayer.Contexts
{
    class DataContext : DbContext
    {
        private readonly IIdentityService ıdentityService;

        public DataContext(DbContextOptions options,IIdentityService ıdentityService)
            : base(options)
        {
            this.ıdentityService = ıdentityService;
        }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly); 
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var changes = this.ChangeTracker.Entries<IAuditableEntity>();
            if (changes!=null)
            {
                foreach (var entry in changes.Where(m => m.State == EntityState.Added
                        || m.State == EntityState.Modified
                        || m.State == EntityState.Deleted))
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedBy= ıdentityService.GetPrincipleId();
                            entry.Entity.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            entry.Property(m => m.CreatedBy).IsModified = false;
                            entry.Property(m => m.CreatedAt).IsModified = false;
                            entry.Entity.LastModifiedBy = ıdentityService.GetPrincipleId();
                            entry.Entity.LastModifiedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entry.Property(m => m.CreatedBy).IsModified = false;
                            entry.Property(m => m.CreatedAt).IsModified = false;
                            entry.Property(m => m.LastModifiedBy).IsModified = false;
                            entry.Property(m => m.LastModifiedAt).IsModified = false;
                            entry.Entity.DeletedBy = ıdentityService.GetPrincipleId();
                            entry.Entity.DeletedAt = DateTime.UtcNow;
                            break;
                        default:
                            break;
                    }
                }
            }
           
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
