using Ardalis.GuardClauses;
using Kwaffeur.Domain.Common;
using System.Collections.Generic;

namespace Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string FirstName { get; }

        public string LastName { get; }

        public Name(string firstName, string lastName)
        {
            Guard.Against.NullOrEmpty(firstName, nameof(firstName));
            Guard.Against.NullOrEmpty(lastName, nameof(lastName));

            FirstName = firstName;
            LastName = lastName;
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return LastName;
        }

        public string FullName => $"{FirstName} {LastName}";
    }
}
