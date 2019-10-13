using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Customers.Queries.GetCustomersList
{
    public class CustomersListViewModel
    {
        public IEnumerable<CustomerLookupDto> Customers { get; set; }
    }

}
