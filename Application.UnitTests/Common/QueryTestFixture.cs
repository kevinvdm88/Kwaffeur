using System;
using AutoMapper;
using Kwaffeur.Application.Common.Mappings;
using Kwaffeur.Persistence;
using Xunit;

namespace Application.UnitTests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public KwaffeurDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = KwaffeurContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            KwaffeurContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}