using Domain.Entities;
using Kwaffeur.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly IKwaffeurDbContext _context;

        public CreateCustomerCommandHandler(IKwaffeurDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = new Customer
            {
                Active = request.Active,
                Address = request.Address,
                ContactData = request.ContactData,
                CustomerType = request.CustomerType,
                Person = request.Person
            };

            _context.Customers.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }


}
