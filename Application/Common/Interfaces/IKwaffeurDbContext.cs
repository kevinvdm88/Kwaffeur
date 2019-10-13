using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Kwaffeur.Application.Common.Interfaces
{
    public interface IKwaffeurDbContext
    {
        DbSet<Customer> Customers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
