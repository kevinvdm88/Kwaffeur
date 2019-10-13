using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using Kwaffeur.Persistence;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KwaffeurWeb.IntegrationTest.Common
{
    public class Utilities
    {
        public static StringContent GetRequestContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        public static async Task<T> GetResponseContent<T>(HttpResponseMessage response)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(stringResponse);

            return result;
        }

        public static void InitializeDbForTests(KwaffeurDbContext context)
        {
            context.Customers.Add(new Customer
            {
                Active = false,
                CustomerType = Domain.Enums.CustomerType.Professional,
                Person = new Person("Jan", "Janssen", GenderType.Male),
                Address = new Address("kerkstraat", "23", "brugge", "West-Vlaanderen", null, null),
                ContactData = new ContactData("kevin.v@riskmatrix.be", null, "+324700706043", null, null)
            });
            context.SaveChanges();
        }
    }
}
