using Application.Customers.Queries.GetCustomersList;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Kwaffeur.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, CustomersListViewModel>
    {
        private readonly IKwaffeurDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomersListQueryHandler(IKwaffeurDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomersListViewModel> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var customers = await _context.Customers
                .ProjectTo<CustomerLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new CustomersListViewModel
            {
                Customers = customers
            };

            return vm;
        }
    }
}
