using System;
using Kwaffeur.Persistence;

namespace Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly KwaffeurDbContext _context;

        public CommandTestBase()
        {
            _context = KwaffeurContextFactory.Create();
        }

        public void Dispose()
        {
            KwaffeurContextFactory.Destroy(_context);
        }
    }
}