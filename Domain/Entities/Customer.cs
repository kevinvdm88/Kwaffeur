using Domain.Enums;
using Domain.ValueObjects;
using Kwaffeur.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Customer : AuditableEntity
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public CustomerType CustomerType { get; set; }
        public Address Address { get; set; }
        public ContactData ContactData { get; set; }
        public bool Active { get; set; }
    }
}