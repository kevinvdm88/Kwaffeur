using Ardalis.GuardClauses;
using Domain.Entities;
using Kwaffeur.Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public static class GuardExtensions
    {
        public static void NullCustomer(this IGuardClause guardClause, int customerId, Customer customer)
        {
            if (customer == null)
                throw new NotFoundException(nameof(Customer), customerId);
        }
    }
}
