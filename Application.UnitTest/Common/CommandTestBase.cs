using Kwaffeur.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UnitTest.Common
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
