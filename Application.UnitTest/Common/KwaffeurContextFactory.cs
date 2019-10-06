using Kwaffeur.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UnitTest.Common
{
    public static class KwaffeurContextFactory
    {
        public static KwaffeurDbContext Create()
        {
            var options = new DbContextOptionsBuilder<KwaffeurDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new KwaffeurDbContext(options);

            context.Database.EnsureCreated();

            //context.Customers.AddRange(new[] {
            //    new Customer { CustomerId = "ADAM", ContactName = "Adam Cogan" },
            //    new Customer { CustomerId = "JASON", ContactName = "Jason Taylor" },
            //    new Customer { CustomerId = "BREND", ContactName = "Brendan Richards" },
            //});

            context.SaveChanges();

            return context;
        }

        public static void Destroy(KwaffeurDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
