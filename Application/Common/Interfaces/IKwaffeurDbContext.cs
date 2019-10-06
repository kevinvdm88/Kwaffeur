using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Kwaffeur.Application.Common.Interfaces
{
    public interface IKwaffeurDbContext
    {
        DbSet<Person> Persons { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
