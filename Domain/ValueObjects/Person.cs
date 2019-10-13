using Ardalis.GuardClauses;
using Domain.Enums;
using Kwaffeur.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class Person : ValueObject
    {
        public GenderType GenderType { get; set; }

        public string FirstName { get; }

        public string LastName { get; }

        public Person(string firstName, string lastName, GenderType genderType)
        {
            Guard.Against.NullOrEmpty(firstName, nameof(firstName));
            Guard.Against.NullOrEmpty(lastName, nameof(lastName));

            FirstName = firstName;
            LastName = lastName;
            GenderType = genderType;
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return LastName;
            yield return GenderType;
        }

        public string FullName => $"{FirstName} {LastName}";
    }
}