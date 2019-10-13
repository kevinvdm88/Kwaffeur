using Application.Common.Exceptions;
using Ardalis.GuardClauses;
using Kwaffeur.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IKwaffeurDbContext _context;

        public DeleteCustomerCommandHandler(IKwaffeurDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers.FindAsync(request.Id);
            Guard.Against.NullCustomer(request.Id, entity);

            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}