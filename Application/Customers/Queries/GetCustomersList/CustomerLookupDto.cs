using AutoMapper;
using Domain.Entities;
using Kwaffeur.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Customers.Queries.GetCustomersList
{
    public class CustomerLookupDto : IMapFrom<Customer>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerLookupDto>();
        }
    }
}
