using Ardalis.GuardClauses;
using Kwaffeur.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class ContactData : ValueObject
    {
        public string Email { get; set; }
        public string VatNumber { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public ContactData(string email, string vatNumber, string mobile, string phone, string fax)
        {
            Guard.Against.NullOrEmpty(email, nameof(email));

            Email = email;
            VatNumber = vatNumber;
            Mobile = mobile;
            Phone = phone;
            Fax = fax;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Email;
            yield return VatNumber;
            yield return Mobile;
            yield return Phone;
            yield return Fax;
        }
    }
}
