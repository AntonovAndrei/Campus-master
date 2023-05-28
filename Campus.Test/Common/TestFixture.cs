using Application.Common;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using AutoMapper;
using Persistence;

namespace Campus.Test.Common;

public class TestFixture : IDisposable
{
    public CampusContext Context;
    public IMapper Mapper;

    public TestFixture()
    {
        Context = CampusContextFactory.Create();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AssemblyMappingProfile(
                typeof(Result<Guid>).Assembly));
        });
        Mapper = configurationProvider.CreateMapper();
    }

    public void Dispose()
    {
        CampusContextFactory.Destroy(Context);
    }
}

[CollectionDefinition("QueryCollection")]
public class QueryCollection : ICollectionFixture<TestFixture> { }