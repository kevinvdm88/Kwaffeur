using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
