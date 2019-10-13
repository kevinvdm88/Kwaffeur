using Kwaffeur.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kwaffeur.Persistence
{
    public class SampleDataSeeder
    {
        private readonly IKwaffeurDbContext _context;
        private readonly IUserManager _userManager;


        public SampleDataSeeder(IKwaffeurDbContext context, IUserManager userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {
            //if (_context.Customers.Any())
            //{
            //    return;
            //}

            //await SeedCustomersAsync(cancellationToken);

            //await SeedRegionsAsync(cancellationToken);

            //await SeedTerritoriesAsync(cancellationToken);

            //await SeedEmployeesAsync(cancellationToken);

            //await SeedUsersAsync(cancellationToken);


        }

        //private async Task SeedUsersAsync(CancellationToken cancellationToken)
        //{
        //    var employees = await _context.Employees
        //        .Where(e => e.UserId == null)
        //        .ToListAsync(cancellationToken);

        //    if (employees.Any())
        //    {
        //        foreach (var employee in employees)
        //        {
        //            var userName = $"{employee.FirstName}@northwind".ToLower();
        //            var userId = await _userManager.CreateUserAsync(userName, "Northwind1!");
        //            employee.UserId = userId;

        //        }

        //        await _context.SaveChangesAsync(cancellationToken);
        //    }
        //}

        //private async Task SeedEmployeesAsync(CancellationToken cancellationToken)
        //{
        //    Employees.Add(1, new Employee
        //    {
        //        City = "Test",
        //        FirstName = "ab",
        //        Country = "Belgium",
        //        Extension = "a"
        //    });


        //    foreach (var employee in Employees.Values)
        //    {
        //        _context.Employees.Add(employee);
        //    }

        //    await _context.SaveChangesAsync(cancellationToken);
        //}

    }

    internal static class OrderExtensions
    {
    }
}