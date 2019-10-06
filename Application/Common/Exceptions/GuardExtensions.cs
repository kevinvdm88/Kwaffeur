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
        public static void NullPerson(this IGuardClause guardClause, int personId, Person person)
        {
            if (person == null)
                throw new NotFoundException(nameof(Person), personId);
        }
    }
}
