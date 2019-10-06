using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Kwaffeur.Application.Common.Interfaces;
using MediatR;
using Application.Common.Exceptions;

namespace Application.Persons.Commands.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IKwaffeurDbContext _context;

        public DeletePersonCommandHandler(IKwaffeurDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Persons.FindAsync(request.Id);

            Guard.Against.NullPerson(request.Id, entity);

            _context.Persons.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
