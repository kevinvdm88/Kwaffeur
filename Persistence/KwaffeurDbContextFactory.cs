using Microsoft.EntityFrameworkCore;


namespace Kwaffeur.Persistence
{
    public class KwaffeurDbContextFactory : DesignTimeDbContextFactoryBase<KwaffeurDbContext>
    {
        protected override KwaffeurDbContext CreateNewInstance(DbContextOptions<KwaffeurDbContext> options)
        {
            return new KwaffeurDbContext(options);
        }
    }
}
