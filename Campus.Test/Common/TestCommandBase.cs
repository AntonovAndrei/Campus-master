using Application.Common;
using Application.Common.Mappings;
using AutoMapper;
using Persistence;

namespace Campus.Test.Common;

public abstract class TestCommandBase : IDisposable
{
    public CampusContext Context;
    public IMapper Mapper;

    public TestCommandBase()
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