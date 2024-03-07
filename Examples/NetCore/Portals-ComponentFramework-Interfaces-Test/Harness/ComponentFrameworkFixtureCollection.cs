using Xunit;

namespace Portals.ComponentFramework.Interfaces.Test.Harness
{
    [CollectionDefinition(nameof(ComponentFrameworkFixtureCollection))]
    public class ComponentFrameworkFixtureCollection : ICollectionFixture<ComponentFrameworkFixture>
    {
    }
}
