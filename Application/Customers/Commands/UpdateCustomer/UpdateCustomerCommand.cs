using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public CustomerType CustomerType { get; set; }
        public Address Address { get; set; }
        public ContactData ContactData { get; set; }
        public bool Active { get; set; }
    }
}
