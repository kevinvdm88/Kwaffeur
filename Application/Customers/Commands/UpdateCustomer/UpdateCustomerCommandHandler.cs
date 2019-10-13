using Application.Common.Exceptions;
using Ardalis.GuardClauses;
using Kwaffeur.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IKwaffeurDbContext _context;

        public UpdateCustomerCommandHandler(IKwaffeurDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers.FindAsync(request.Id);
            Guard.Against.NullCustomer(request.Id, entity);

            entity.Active = request.Active;
            entity.Address = request.Address;
            entity.ContactData = request.ContactData;
            entity.CustomerType = request.CustomerType;
            entity.Person = request.Person;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
