using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kwaffeur.Application.Common.Interfaces;
using Kwaffeur.Common;
using Kwaffeur.Domain.Common;
using Kwaffeur.Domain.Entities;

namespace Kwaffeur.Persistence
{
    public class KwaffeurDbContext : DbContext, IKwaffeurDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public KwaffeurDbContext(DbContextOptions<KwaffeurDbContext> options)
            : base(options)
        {
        }

        public KwaffeurDbContext(
            DbContextOptions<KwaffeurDbContext> options,
            ICurrentUserService currentUserService,
            IDateTime dateTime)
            : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public DbSet<Employee> Employees { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = _currentUserService.GetUserId();
                    entry.Entity.Created = _dateTime.Now;

                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.LastModifiedBy = _currentUserService.GetUserId();
                    entry.Entity.LastModified = _dateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KwaffeurDbContext).Assembly);
        }
    }
}
