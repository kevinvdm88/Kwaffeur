using Kwaffeur.Application.Common.Interfaces;
using Kwaffeur.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Kwaffeur.Application.System.Commands.SeedSampleData
{
    public class SeedSampleDataCommand : IRequest
    {
    }

    public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand>
    {
        private readonly IKwaffeurDbContext _context;
        private readonly IUserManager _userManager;

        public SeedSampleDataCommandHandler(IKwaffeurDbContext context, IUserManager userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new SampleDataSeeder(_context, _userManager);

            await seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
